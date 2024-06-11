#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#This line sets the base image for the "base" stage of the build process.
#The image used is mcr.microsoft.com/dotnet/aspnet:8.0, which is the .NET 8.0 runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#This line sets the user for the "base" stage to be app.
USER app
#Sets the working directory for the "base" stage to be /app.
WORKDIR /app
#This line exposes port 8080 for the "base" stage.
EXPOSE 8080
#This line exposes port 8081 for the "base" stage.
EXPOSE 8081



#This line sets the base image for the "build" stage of the build process.
#The image used is mcr.microsoft.com/dotnet/sdk:8.0, which is the .NET 8.0 SDK image.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#This line sets the default value for the BUILD_CONFIGURATION argument to be "Release".
#This argument can be overridden when building the Docker image.
ARG BUILD_CONFIGURATION=Release
#Sets the working directory for the "build" stage to be /src.
WORKDIR /src
#This line copies the project file (RandomJoke.Web.csproj) from the host machine to the /src/RandomJoke.Web/ directory in the container.
COPY ["RandomJoke.Web/RandomJoke.Web.csproj", "RandomJoke.Web/"]
#This line runs the dotnet restore command to restore the project dependencies.
RUN dotnet restore "./RandomJoke.Web/RandomJoke.Web.csproj"
#This line copies the entire contents of the current directory (including all source files) to the /src/ directory in the container.
COPY . .
#This line sets the working directory to the RandomJoke.Web directory.
WORKDIR "/src/RandomJoke.Web"
#This line runs the dotnet build command to build the project in the specified $BUILD_CONFIGURATION (which defaults to "Release") 
#and outputs the built artifacts to the /app/build directory.
RUN dotnet build "./RandomJoke.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build


#This line starts a new stage called "publish" and uses the "build" stage as its base.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
#This line runs the dotnet publish command to publish the project in the specified $BUILD_CONFIGURATION (which defaults to "Release")
#and outputs the published artifacts to the /app/publish directory.
#The /p:UseAppHost=false parameter is used to disable the creation of a self-contained executable, which reduces the size of the final Docker image.
RUN dotnet publish "./RandomJoke.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


#This line starts the final stage of the build process and uses the "base" stage as its base.
FROM base AS final
#This line sets the working directory for the "final" stage to be /app.
WORKDIR /app
#This line copies the published artifacts from the "publish" stage to the current working directory in the "final" stage.
COPY --from=publish /app/publish .
#This line sets the entrypoint for the final Docker image, which will run the RandomJoke.Web.dll application when the container is started.
ENTRYPOINT ["dotnet", "RandomJoke.Web.dll"]