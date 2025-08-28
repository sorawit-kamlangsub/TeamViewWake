$info = [PSCustomObject]@{
  User         = (whoami)
  IsAdmin      = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
  PWD          = (Get-Location).Path
  PATH_Short   = ($env:PATH -split ';' | Select-Object -First 8) -join ';'
  Arch         = (Get-CimInstance Win32_OperatingSystem).OSArchitecture
  Drives       = (Get-PSDrive -PSProvider FileSystem | ForEach-Object { $_.Name + ':' }) -join ' '
}
$info | Format-List