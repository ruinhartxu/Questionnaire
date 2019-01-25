# Questionnaire

Please fork this repository, clone locally, and complete the following task. Please ensure to commit your work between each task. Please push your work to github, and let us know the link to your repository.

# Azure VM

Please feel free to complete any of the following in the azure vm provided to you via email.

# Powershell 

Please save the following items as individual powershell scripts/modules. 

* Write a powershell script to Install/Configure the following on Windows Server
    * .Net 4.5 
    * .Net Core
    * A firewall rule allowing port 1433 on firewall
    * write a registery key in User's registry folder. [Key]:[Value] == Company:MCU


* Write a script to remotely retrieve name of services on a machine that are currently running, and Stop a given service if currently running.
* Write a script to map a network drive, and persist said mapping.
* Write a script to run a given stored procedure, against a given sql server. Export output - if any - to a csv file at a given path.


# C#

* Create a console application, where:
    * Three randum numbers between 1 and 10 are generated
    * User is given 3 chances to guess the number
    * Once user has guessed the number correctly, show success message. Otherwise show failed message.


# C# WebAPI

* Create webAPI using c#
* Use entity framework, to design the following database:

| [Column] | [Type] | [Null]|
|---|---|---|
| ID | int | false |
| ProductName | varchar | false |
| Quantity | int | false | 

* Create the following constraints using EF:
    * ProductName to be unique
    * Quantity to range from 0
    * ID to be Key

* Create a CRUD contoller for this model.
* Enable Windows Authorization for the API, and allow only Authorized users to commit Put/Post requests to above mentioned controller.
* Set up a Web Deploy publish profile for this API

# Angular 

* Create a dashboard for the webAPI created above using angular 
* Using angular, create CRUD controller for the API above. 
* Create a single page application to allow user to see a list of Production, Delete, Updated, or create new products. 

