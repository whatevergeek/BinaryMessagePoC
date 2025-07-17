@echo off
echo Building BinaryMessageCodec NuGet package...

:: Create Release directory if it doesn't exist
if not exist "BinaryMessageCodec\bin\Release" mkdir "BinaryMessageCodec\bin\Release"

dotnet pack -c Release BinaryMessageCodec\BinaryMessageCodec.csproj

echo.
echo Package created in BinaryMessageCodec\bin\Release\
echo.
echo To publish to NuGet.org:
echo dotnet nuget push BinaryMessageCodec\bin\Release\BinaryMessageCodec.1.0.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
echo.
echo To use locally:
echo dotnet add package BinaryMessageCodec --source %CD%\BinaryMessageCodec\bin\Release
echo.

pause