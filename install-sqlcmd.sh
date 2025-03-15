#!/bin/bash

# SQLServer コンテナに sqlcmd をインストールするスクリプト

# コンテナが実行中かチェック
if ! docker ps | grep -q sqlserver; then
  echo "SQLServer コンテナが実行されていません"
  exit 1
fi

echo "SQLServer コンテナに sqlcmd をインストールしています..."

# rootユーザーとしての操作を分割して実行
# 1. 必要なディレクトリとパーミッションを設定
docker exec -u 0 sqlserver bash -c "
mkdir -p /usr/local/bin
chmod 755 /usr/local/bin
"

# 2. sqlcmdをインストール
docker exec -u 0 sqlserver bash -c "
apt-get update && \
apt-get install -y curl gnupg2 && \
curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
apt-get update && \
ACCEPT_EULA=Y apt-get install -y mssql-tools18 unixodbc-dev
"

# 3. シンボリックリンクを作成
docker exec -u 0 sqlserver bash -c "
ln -sf /opt/mssql-tools18/bin/sqlcmd /usr/local/bin/sqlcmd
chmod 755 /usr/local/bin/sqlcmd
"

# 4. パス設定
docker exec -u 0 sqlserver bash -c "
echo 'export PATH=\"\$PATH:/opt/mssql-tools18/bin:/usr/local/bin\"' > /etc/profile.d/mssql-tools.sh && \
chmod +x /etc/profile.d/mssql-tools.sh && \
echo 'source /etc/profile.d/mssql-tools.sh' >> /etc/bash.bashrc
"


# インストール結果を確認（より具体的な方法）
if docker exec -it sqlserver bash -c "test -x /opt/mssql-tools18/bin/sqlcmd"; then
  echo "sqlcmd が正常にインストールされました"
  echo "以下のコマンドでSQLServerに接続できます："
  echo "docker exec -it sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P \"Dosukoi100kg@\" -C -N"
  
  # シンボリックリンクの確認
  if docker exec -it sqlserver bash -c "test -x /usr/local/bin/sqlcmd"; then
    echo ""
    echo "シンボリックリンクも作成されました。以下のコマンドでも接続できます："
    echo "docker exec -it sqlserver sqlcmd -S localhost -U sa -P \"Dosukoi100kg@\" -C -N"
  else
    echo ""
    echo "注意: /usr/local/bin/sqlcmd へのシンボリックリンクが作成されていないか、実行権限がありません"
  fi
else
  echo "sqlcmd のインストールに失敗しました"
  exit 1
fi