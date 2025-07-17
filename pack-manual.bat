@echo off
echo Building BinaryMessageCodec NuGet package...

:: Build the project
dotnet build -c Release BinaryMessageCodec\BinaryMessageCodec.csproj

:: Create NuGet package using nuspec
nuget pack BinaryMessageCodec\BinaryMessageCodec.nuspec -OutputDirectory .\packages

echo.
echo Package created in .\packages\
echo.
echo To publish to NuGet.org:
echo nuget push .\packages\BinaryMessageCodec.1.0.0.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey YOUR_API_KEY
echo.
echo To use locally:
echo nuget add .\packages\BinaryMessageCodec.1.0.0.nupkg -Source %CD%\packages
echo.

pause