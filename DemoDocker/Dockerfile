#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DemoDocker/DemoDocker.csproj", "DemoDocker/"]
COPY ["DemoDocker.Service/DemoDocker.Service.csproj", "DemoDocker.Service/"]
COPY ["DemoDocker.Infastructure.EF/DemoDocker.Infastructure.EF.csproj", "DemoDocker.Infastructure.EF/"]
COPY ["DemoDocker.Shared/DemoDocker.Shared.csproj", "DemoDocker.Shared/"]
RUN dotnet restore "DemoDocker/DemoDocker.csproj"
COPY . .
WORKDIR "/src/DemoDocker"
RUN dotnet build "DemoDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoDocker.dll"]