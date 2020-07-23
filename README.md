`dotnet new sln`

`dotnet new webapi -o PowerMeterApi`

`dotnet sln power-meter-api.sln add PowerMeterApi`

`dotnet new xunit -o PowerMeterApi.Tests`

`dotnet sln power-meter-api.sln add PowerMeterApi.Tests`



# Docker Commands. 

`docker build --pull -t power-meter-api .`

`docker-compose -f docker-compose.yml up -d`

`docker run --rm -it -p 8000:80 -e ASPNETCORE_ConnectionStrings__MeterDbConnectionString="Server=host.docker.internal;Database=meter_db;User Id=sa;Password=Pass1234" power-meter-api`