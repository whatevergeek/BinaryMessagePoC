@echo off
echo Building BinaryMessageCodec NuGet package for .NET 8.0...

:: Create output directory if it doesn't exist
if not exist "packages" mkdir packages

:: Clean and build
dotnet clean -c Release
dotnet build -c Release

:: Create NuGet package
dotnet pack -c Release BinaryMessageCodec\BinaryMessageCodec.csproj -o packages

echo.
echo Package created in .\packages\
echo.
echo To publish to NuGet.org:
echo dotnet nuget push packages\BinaryMessageCodec.1.0.1.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
echo.
echo To use locally:
echo dotnet add package BinaryMessageCodec --source %CD%\packages
echo.

pause