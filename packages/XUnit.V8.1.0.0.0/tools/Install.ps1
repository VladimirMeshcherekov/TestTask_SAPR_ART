param($installPath, $toolsPath, $package, $project)

$platforms = @("x86", "x64")

$copyToOutDirDlls = @("msvcp100.dll", "msvcr100.dll", "Noesis.Javascript.dll", "xUnit.V8.Noesis.Proxy.x86.dll", "xUnit.V8.Noesis.Proxy.x64.dll")

foreach($platform in $platforms) {
	$platformFolder = $project.ProjectItems.Item($platform)

	$foundProjectItems = $platformFolder.ProjectItems | Where-Object { $copyToOutDirDlls -match $_.Name };

	foreach ($projectItem in $foundProjectItems) {
		$itemName = $projectItem.Name
		Write-Host  "Setting 'Copy if newer' on item $itemName"
		# set 'Copy To Output Directory' to 'Copy if newer'
		$copyToOutputProperty = $projectItem.Properties.Item("CopyToOutputDirectory")
		$copyToOutputProperty.Value = 2
	}
}
