# Use the official .NET base image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the entire solution (all projects) to the container
COPY ../SkillHub.sln ./
COPY ../SkillHub.UserService/SkillHub.UserService.csproj ./SkillHub.UserService/
COPY ../SkillHub.Application/SkillHub.Application.csproj ./SkillHub.Application/
COPY ../SkillHub.Domain/SkillHub.Domain.csproj ./SkillHub.Domain/
COPY ../SkillHub.Infrastructure/SkillHub.Infrastructure.csproj ./SkillHub.Infrastructure/

# Run ls to verify the files have been copied correctly
RUN ls -al /src  # List files in the /src directory to verify the copied files

# Restore the dependencies (this ensures that we only rebuild if the dependencies change)
RUN dotnet restore

# Copy the remaining files
COPY ../SkillHub.UserService/ ./SkillHub.UserService/
COPY ../SkillHub.Application/ ./SkillHub.Application/
COPY ../SkillHub.Domain/ ./SkillHub.Domain/
COPY ../SkillHub.Infrastructure/ ./SkillHub.Infrastructure/

## Run ls again to verify that the files were copied correctly
#RUN ls -al /src  # Check if the rest of the files are copied
#RUN ls -al /app   # Check the /app directory

# Build the application
RUN dotnet publish SkillHub.UserService/SkillHub.UserService.csproj -c Release -o /app/publish

# Final stage: use the base image and copy the published app files
FROM base AS final
WORKDIR /app

# Ensure /app directory exists in the final image
RUN mkdir -p /app/publish

# Copy the published files from the build stage into the final image
COPY --from=build /app/publish .

# Define entry point for the application
ENTRYPOINT ["dotnet", "SkillHub.UserService.dll"]
