FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OcelotCustomHeader/OcelotCustomHeader.csproj", "OcelotCustomHeader/"]
RUN dotnet restore "OcelotCustomHeader/OcelotCustomHeader.csproj"
COPY . .
WORKDIR "/src/OcelotCustomHeader"
RUN dotnet build "OcelotCustomHeader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotCustomHeader.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotCustomHeader.dll"]
