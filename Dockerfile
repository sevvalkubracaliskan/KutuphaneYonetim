# 1. Aşama: Derleme (SDK 9.0 kullanıyoruz)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Proje dosyasını kopyalayıp bağımlılıkları geri yüklüyoruz
COPY *.csproj ./
RUN dotnet restore

# Diğer tüm dosyaları kopyalayıp yayınlıyoruz
COPY . ./
RUN dotnet publish -c Release -o out

# 2. Aşama: Çalıştırma (Runtime 9.0 kullanıyoruz)
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "KutuphaneYonetim.dll"]