# _LocalBusiness.Solution_

#### By _Zhibin Liang

#### An ASP.NET Core Web API provides info of local business

---
## Table of Contents
[Technologies Used](#technologies-used)  
[Description](#description)  
[Setup/Installation Requirements](#setup-and-installation-requirements)
[API Documentation](#api-documentation)
[Known Bugs](#known-bugs)  
[License](#License)

---
## Technologies Used

* C#
* HTML/CSS
* MySQL
* ASP.NET CORE

---
## Description
This is an ASP.NET Core Web API provides info of local business. A user can create, read, update and delete info of local businesses. Predefined users can get token with their user name and password to access the user list.

---
## Setup and Installation Requirements
<details>
<summary><strong>Prerequisites</strong></summary>

* Requires _MySQL_ for the database
* Install _Microsoft .NET SDK_
* Install dotnet script with ```dotnet tool install -g dotnet-script```
* (Optional) Install Postman
</details>

<details>
<summary><strong>To Setup</strong></summary>

* Clone the repo
    ```
    $ git clone https://github.com/zbl14/LocalBussiness.Solution.git
    ```
</details>

<details>
<summary><strong>Configuration</strong></summary>

* Create ```appsettings.json``` in the directory of _LocalBusiness_ 
   <pre>LocalBusiness.Solution
    └─┬ LocalBusiness
      └── <strong>appsettings.json</strong></pre>

* Add following code to ```appsettings.json```. Replace [username] and [password] with your MySQL username and password. Replace [secret] with yours which will be encrypted into tokens
    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Warning",
          "System": "Information",
          "Microsoft": "Information"
        }
      },
      "AllowedHosts": "*",
      "JWT": {
        "Key": "[secret]"
      },
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=local_business;uid=[username];pwd=[password];"
      }
    }
    ```
</details>

<details>
<summary><strong>To Run</strong></summary>

* Run follwing commands in the terminal
    ```
    $ dotnet restore
    ```
    ```
    $ dotnet ef database update
    ```
    ```
    $ dotnet run
    ```
</details>

---
## API Documentation

### Using Swagger Documentation

To explore LocalBusiness API with Swagger/Swashbuckle, launch the project using `dotnet run` with the terminal or Powershell

### Using the JSON Web Token

* Make a POST call to the following endpoint ```http://localhost:5000/api/users/authenticate``` with Postman
* The body of the API call will look like below code. Replace [username] and [password] with predefined username and password
    ```json
    {
      "username": "[username]",
      "password": "[password]"
    }
    ```
### Note on CORS
* LocalBusiness.Solution is a CORS enabled API.
* CORS is a W3C standard that allows a server to relax the same-origin policy. It is not a security feature, CORS relaxes security. It allows a server to explicitly allow some cross-origin requests while rejecting others. An API is not safer by allowing CORS. For more information or to see how CORS functions, see the [Microsoft documentation](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.2#how-cors).

## Endpoints

Base URL: https://localhost:5000

## HTTP Request Structure
```
GET /api/businesses
POST /api/businesses
GET /api/businesses/{id}
PUT /api/businesses/{id}
DELETE /api/businesses/{id}
```

### Example Query
```
http://localhost:5000/api/businesses/5
```

### Sample JSON Response
```json
[
  {
    "businessId": 5,
    "name": "Mayce",
    "type": "Shop",
    "phone": "9092226789",
    "address": "678 Tomson Street, Tustin Ca 92780"
  }
]
```

## Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| name | string | none | true | Return matches by name.
| type | string | none | true | Return matches by type.
| phone | string | none | true | Return matches by phone number.
| address | string | none | true | Return matches by address.

## Example Query
```
http://localhost:5000/api/businesses/?name=Duke%20Bakery
```

## Sample JSON Response
```
[
    {
        "businessId": 3,
        "name": "Duke Bakery",
        "type": "Restaurant",
        "phone": "8883332345",
        "address": "45 Jaboree Road, Irvine, Ca 92618"
    }
]
```

This program was built using *`Microsoft .NET SDK 5.0.401`*, and may not be compatible with other versions. Your milage may vary.

---
## Known Bugs

* No known bugs, feel free to contact me here if any are found.

---
## License
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Contact Information
Zhibin Liang <ifthereisoneday@gmail.com>

[Copyright](/LICENSE) &copy; 2022 Zhibin Liang