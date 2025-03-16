# ASP.NET Core MVC Ver8の学習  
## *☆ASP.NET Core MVCのチュートリアルです*  

## ただいま工事中です  

- Visual StudioではビルドするとWebアプリを起動できます。  
  
- Dockerコンテナ環境では、mvc_movieコンテナに入って以下のコマンドを実行してください。  
#### ・コンテナに入る
#### bash
```
$ docker exec -it mvc_movie bash
```
<br>

#### ・コンテナ内でのコマンドライン
#### bash
```
# dotnet ef database update
```

#### ・Webアプリを起動
#### bash
```
# ・dotnet run --urls=http://+:8080 

または 

・dotnet watch run --urls=http://+:8080 
```

