# Build .NET application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet build -c Release -o /app/out

# Build Angular application
FROM node:18-alpine AS client-build-env
WORKDIR /app

COPY --from=build-env /app/clientApp ./

RUN npm install

RUN ng build --output-path dist

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build-env /app/out .
COPY --from=client-build-env /app/dist /app/clientApp

EXPOSE 80

# Configure ASP.NET to serve static files from /app/clientApp
ENTRYPOINT ["dotnet", "YourApplication.dll", "--urls", "http://*:80", "--contentroot", "/app"]
