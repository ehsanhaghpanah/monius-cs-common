
cls
echo "deploying..."

nuget pack .\Core\Common\Data\Data.csproj -Verbosity detailed -Properties Configuration=Release -Prop Platform=x64

ls moniüs.Common.*.nupkg

move .\moniüs.Common.*.nupkg C:\NuGet\G4 -Force

echo "deploy completed,"

ls C:\NuGet\G4\moniüs.Common.*.nupkg