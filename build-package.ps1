Write-Host "Building BinaryMessageCodec NuGet package..." -ForegroundColor Cyan

# Ensure output directory exists
$outputDir = ".\BinaryMessageCodec\bin\Release"
if (-not (Test-Path $outputDir)) {
    New-Item -ItemType Directory -Path $outputDir -Force | Out-Null
}

# Build and pack
dotnet build -c Release .\BinaryMessageCodec\BinaryMessageCodec.csproj
dotnet pack -c Release .\BinaryMessageCodec\BinaryMessageCodec.csproj -o $outputDir

Write-Host "`nPackage created in $outputDir" -ForegroundColor Green

# Show next steps
Write-Host "`nTo publish to NuGet.org:" -ForegroundColor Yellow
Write-Host "dotnet nuget push $outputDir\BinaryMessageCodec.1.0.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json"

Write-Host "`nTo use locally:" -ForegroundColor Yellow
Write-Host "dotnet add package BinaryMessageCodec --source $((Get-Location).Path)\BinaryMessageCodec\bin\Release"

Write-Host "`nPress any key to continue..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")