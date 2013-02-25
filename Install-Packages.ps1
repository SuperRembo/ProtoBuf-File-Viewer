$scriptDir = split-path $script:MyInvocation.MyCommand.Path
$nuget = "$scriptDir\Tools\NuGet.exe"
$packagesDir = "$scriptDir\Packages"
$packageSource = "https://nuget.org/api/v2/"

$packagesConfigs = get-content "$packagesDir\Repositories.config" `
    | select-string -pattern "<repository path=" `
    | foreach { $_ -replace "\s*<repository path=""", """$packagesDir\" } `
    | foreach { $_ -replace "\s*/>" }

foreach ($pathToPackagesConfig in $packagesConfigs) 
{ 
    & $nuget install $pathToPackagesConfig -o $packagesDir -Source $packageSource
}
