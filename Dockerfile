FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY ApiAutomationTests/ ./ApiAutomationTests/
WORKDIR /app/ApiAutomationTests
RUN dotnet restore

RUN dotnet build --no-restore
RUN dotnet test --no-build --logger:"console;verbosity=normal"

