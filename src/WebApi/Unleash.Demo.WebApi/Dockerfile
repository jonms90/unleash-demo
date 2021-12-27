#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/WebApi/Unleash.Demo.WebApi/Unleash.Demo.WebApi.csproj", "src/WebApi/Unleash.Demo.WebApi/"]
RUN dotnet restore "src/WebApi/Unleash.Demo.WebApi/Unleash.Demo.WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi/Unleash.Demo.WebApi"
RUN dotnet build "Unleash.Demo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unleash.Demo.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unleash.Demo.WebApi.dll"]