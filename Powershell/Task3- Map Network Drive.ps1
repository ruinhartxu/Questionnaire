
## Map a network drive and keep persistent

Write-Host "Now starting map network drive...."

net use P: \\myComputer\shared /persistent:yes

pause