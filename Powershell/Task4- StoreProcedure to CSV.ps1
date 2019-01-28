## Export to csv

$proName="dbo.uspGetProducts"

Write-Host "Now executing $proName, then export to a csv file..."

$SqlConnection = New-Object System.Data.SqlClient.SqlConnection
$SqlConnection.ConnectionString = "Server=localhost\SQLEXPRESS;Database=MCU;Initial Catalog=MCU;Persist Security Info=True;User ID=MCU;Password=123123"
$SqlCmd = New-Object System.Data.SqlClient.SqlCommand
$SqlCmd.CommandText = $proName
$SqlCmd.Connection = $SqlConnection
$SqlAdapter = New-Object System.Data.SqlClient.SqlDataAdapter
$SqlAdapter.SelectCommand = $SqlCmd
$DataSet = New-Object System.Data.DataSet
$SqlAdapter.Fill($DataSet)
$SqlConnection.Close()
$DataSet.Tables[0] | Export-Csv -Path F:\Projects\results.csv -notypeinformation

