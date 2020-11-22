# FunnyLolz
## Overview
Attached is some code written for an interview test. The requirement was to:

Create an application that accesses a 3rd party API, displaying data on the screen in any way suitable. To achieve this, I decided to be funny, and create an old school Console app to display the data, and connecte to a new school Web API endpoint which I wrote. This would use basic httpClient.

From there, the API will connect to the 3rd part endpoint, retreive data and return a formatted response to the client.

![demo](https://s8.gifyu.com/images/2da967e460c24dc67.gif)

Ideas to demonstrate:

* Dependency injection on the API layer, to assist with unit testing.
* Dependency injection of httpClient in the API layer.
* Basic Error handling
* Unit Testing
* Layered application development to assist with unit testing and code segragation
* Linq, Regex to handle data and searches of data for the term searches
* Swagger as and Endpoint documentation tool (/swagger)

The project was coded in Visual Studion 2019 Community Edition, and is based on latest updates. 
It makes use of .Net Core 3.1.404

## To run the solution:

1. Ensure that the solution runs two projects:
* API - This will run the API endpoint
* UI - This will run the UI client app.

![run the projects](https://i.ibb.co/L85m4Bk/1.png)

Note, swagger is available on the /swagger url:

![swagger](https://i.ibb.co/q0wYxZ2/1.png)

Extremely basic unit tests are available in the Test Explorer.

![run the tests](hhttps://i.ibb.co/CPsxDJg/2.png)

They should pass... hopefully.
