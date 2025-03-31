# Etapa base para el runtime de la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa para el build de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AdquisicionesAPI.csproj", "./"]
RUN dotnet restore "./AdquisicionesAPI.csproj"

# Copiar y compilar el proyecto
COPY . .
RUN dotnet build "AdquisicionesAPI.csproj" -c Release -o /app/build

# Publicar el proyecto
FROM build AS publish
RUN dotnet publish "AdquisicionesAPI.csproj" -c Release -o /app/publish

# Generación de imagen
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdquisicionesAPI.dll"]