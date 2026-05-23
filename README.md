Do uruchomienia projektu potrzebna jest baza danych na przykład LocalDB. Pod taką jest też stworzony domyślny connection string.
Należy z folderu uruchomić:  
`dotnet ef migrations add Creation` - stworzenie migracji dla bazy danych  
`dotnet ef database update` - zaaplikowanie migracji na rzeczywistej bazie  
`dotnet run` - uruchomienie aplikacji, dostęp do swaggera pod localhost:5163/swagger
