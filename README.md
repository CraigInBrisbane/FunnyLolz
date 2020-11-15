# FunnyLolz
## Overview
Attached is some code written for an interview test. The requirement was to:

Create an application that accesses a 3rd party API, displaying data on the screen in any way suitable. To achieve this, I decided to be funny, and create an old school Console app to display the data, and connecte to a new school Web API endpoint which I wrote. This would use basic httpClient.

From there, the API will connect to the 3rd part endpoint, retreive data and return a formatted response to the client.

Ideas to demonstrate:

* Dependency injection on the API layer, to assist with unit testing.
* Dependency injection of httpClient in the API layer.
* Error handling
* Unit Testing (XUnit)
* Layered application development to assist with unit testing and code segragation
* Linq to handle searches of data for the term searches
* Swagger as and Endpoint documentation tool
* JWT Tokens to achieve some form of security

Unfortunately, I expended my time, probably due to over-engineering, but I wanted to demonstrate key askpects of my development.

The project was coded in Visual Studion 2019 Community Edition, and is based on latest updates. 
It makes use of .Net Core 3.1.404

## To run the solution:

1. Ensure that the solution runs two projects:
* API - This will run the API endpoint
* UI - This will run the UI client app.

## What I'd have done next

* Complete option 2 - the Terms.
* Add Swagger to allow for easy reading of the API endpoints.
* Moved hard coded items (url, ports etc) into Appsettings.json
* Enhanced error handling
* Added a console log sync to log items somewhere


But poor planning on my part, didn't allow me to complete this in the allocated 3 hours.
