FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY PowerMeterApi/*.csproj ./PowerMeterApi/
COPY PowerMeterApi.Tests/*.csproj ./PowerMeterApi.Tests/
RUN dotnet restore

# copy everything else and build app
COPY PowerMeterApi/. ./PowerMeterApi/
WORKDIR /app/PowerMeterApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/PowerMeterApi/out ./
ENTRYPOINT ["dotnet", "PowerMeterApi.dll"]