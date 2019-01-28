##
## Get all runing services on remote computer

$computername="myComputer"
$serviceName="myService"

Write-Host "Now retriving all runing services on $computername"


Get-Service -ComputerName $computername | Where-Object {$_.Status -eq "Running"}


## Stop a service

Write-Host "Now stop a service on $computername"

(Get-Service -ComputerName $computername -Name $service | Where-Object {$_.Status -eq "Running"}).stop()

pause