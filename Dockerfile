# Use official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set working directory
WORKDIR /app

# Copy project and restore
COPY ApiAutomationTests/ ./ApiAutomationTests/
WORKDIR /app/ApiAutomationTests
RUN dotnet restore

# Build and test
RUN dotnet build --no-restore
RUN dotnet test --no-build --logger:"console;verbosity=normal"

