@echo off
echo Cleaning up build artifacts...

:: Clean solution
dotnet clean

:: Remove any remaining build artifacts
rmdir /s /q "BinaryMessageCodec\bin" 2>nul
rmdir /s /q "BinaryMessageCodec\obj" 2>nul
rmdir /s /q "BinaryMessageConsole\bin" 2>nul
rmdir /s /q "BinaryMessageConsole\obj" 2>nul

echo.
echo Building solution with .NET 8.0...
dotnet build -c Debug

echo.
echo Done!
pause