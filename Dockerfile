# Build & Publish Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["Lotka/Lotka.csproj", "Lotka/"]
RUN dotnet restore "Lotka/Lotka.csproj"

# Copy all files and publish
COPY . .
WORKDIR "/src/Lotka"
RUN dotnet publish "Lotka.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_HTTP_PORTS=10000
ENV ASPNETCORE_URLS=http://+:10000
ENV PORT=10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "Lotka.dll"]
