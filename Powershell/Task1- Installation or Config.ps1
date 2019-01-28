
## Install .net 4.5

 Write-Host "Now installing .net 4.5..."


 Start-Process -FilePath "F:\Projects\dotNetFx45_Full_setup.exe" -ArgumentList "/q/norestart" -Wait


 
 ## Install .net core
 
  Write-Host "Now installing .net core..."


 Start-Process -FilePath "F:\Projects\dotnet-hosting-2.2.1-win.exe" -ArgumentList "/q/norestart" -Wait


 
 ## open port 1433
 
  Write-Host "Now opening port 1433 on firewall..."

  New-NetFirewallRule -DisplayName "Open 1433" -Direction Inbound -Action Allow -LocalPort 1433 -Protocol TCP


 
 ## Write a registry key in Users
 
  Write-Host "Now writing a registry key company:MCU..."

  
 New-ItemProperty -Path "HKCU:\" -Name "Company" -Value "MCU" -PropertyType String -Force | Out-Null


 pause

