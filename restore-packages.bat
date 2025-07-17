@echo off
echo Restoring NuGet packages...

:: Restore packages
dotnet restore BinaryMessageConsole\BinaryMessageConsole.csproj

echo.
echo Done!
pause