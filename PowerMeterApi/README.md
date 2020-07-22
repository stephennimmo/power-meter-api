`cd PowerMeterApi`

`dotnet add package Microsoft.EntityFrameworkCore`

`dotnet add package Microsoft.EntityFrameworkCore.SqlServer`

`dotnet add package dbup`

# Run Local

From PowerMeterApi project folder...

`docker-compose up -d` # Starts SQL Server 2019 Container

`export ASPNETCORE_ConnectionStrings__MeterDbConnectionString="Server=localhost;Database=meter_db;User Id=sa;Password=Pass1234"`

`dotnet run`