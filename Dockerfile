FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# プロジェクトファイルをコピーして依存関係を復元
COPY ["MvcMovie.csproj", "./"]
RUN dotnet restore "MvcMovie.csproj"

# ソースコードをコピーしてビルド
COPY . .
RUN dotnet build "MvcMovie.csproj" -c Release -o /app/build

# 公開
FROM build AS publish
RUN dotnet publish "MvcMovie.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 最終イメージ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
ENV APP_UID=1654 \
    ASPNETCORE_HTTP_PORTS=8080 \
    DOTNET_RUNNING_IN_CONTAINER=true

# ユーザー作成部分を条件付きで実行（既存のグループがない場合のみ作成）
RUN if ! getent group app; then \
        groupadd --gid=$APP_UID app; \
    fi && \
    if ! getent passwd app; then \
        useradd -l --uid=$APP_UID --gid=$APP_UID --create-home app; \
    fi

WORKDIR /app
COPY --from=publish /app/publish .

# 実行権限の設定
RUN chown -R $APP_UID:$APP_UID /app

# 必要なポートを公開
EXPOSE 8080
EXPOSE 8081

# 非root権限ユーザーに切り替え
USER $APP_UID

# コンテナ起動時に実行されるコマンド
ENTRYPOINT ["dotnet", "MvcMovie.dll"]