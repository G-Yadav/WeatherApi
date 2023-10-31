# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
ARG TARGETARCH
WORKDIR /work

# copy csproj and restore as distinct layers
COPY "src/com.weather.api/com.weather.api.csproj" "src/com.weather.api/"
COPY "src/com.weather.business/com.weather.business.csproj" "src/com.weather.business/"
COPY "src/com.weather.domain/com.weather.domain.csproj" "src/com.weather.domain/"
COPY "src/com.weather.infrastructure/com.weather.infrastructure.csproj" "src/com.weather.infrastructure/"
COPY *.sln .
RUN dotnet restore "src/com.weather.api/" -a $TARGETARCH

# copy and publish app and libraries
COPY . .
WORKDIR "src/com.weather.api/"
RUN dotnet publish "com.weather.api.csproj" -a $TARGETARCH -c Release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-jammy
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["dotnet", "com.weather.api.dll"]