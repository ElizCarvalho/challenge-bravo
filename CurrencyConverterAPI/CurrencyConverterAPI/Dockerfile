FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_URLS=http://*:5000
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 as test
WORKDIR /src
COPY ["CurrencyConverterAPI/CurrencyConverterAPI.csproj", "CurrencyConverterAPI/"]
COPY ["CurrencyConverterAPITests/CurrencyConverterAPITests.csproj", "CurrencyConverterAPITests/"]
RUN dotnet restore "CurrencyConverterAPI/CurrencyConverterAPI.csproj"
RUN dotnet restore "CurrencyConverterAPITests/CurrencyConverterAPITests.csproj"
COPY . .
WORKDIR "/src/CurrencyConverterAPITests"
RUN dotnet test "CurrencyConverterAPITests.csproj"

FROM test AS build
WORKDIR "/src/CurrencyConverterAPI"
RUN dotnet build "CurrencyConverterAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CurrencyConverterAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN apt-get update && apt-get install curl -y
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurrencyConverterAPI.dll"]