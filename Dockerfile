# 1. Aşama: Derleme (SDK 9.0 kullanıyoruz)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# 2. Aşama: Çalıştırma (Runtime 9.0 kullanıyoruz)
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Render PORT verir; uygulama o porta dinlesin
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
EXPOSE 8080

ENTRYPOINT ["dotnet", "KutuphaneYonetim.dll"]