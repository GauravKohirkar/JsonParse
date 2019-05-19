# JsonParse
Json Parsing Api with Console App consuming the Api in C#

## Getting Started

This project consists of 2 solutions. JsonParse.Api and JsonParse. 

## Running Application

```
In order to run the application, you need to run the JsonParse.Api on http://localhost:54238/api/jsonParse endpoint.
The Endpoint and environment path of the file can be configured from the App.config of the console application JsonParse.App.
```
```
Then start the console app from JsonParse solution file to consume this Api endpoint.
```

## Running the tests

The Json.Api.Tests is there for testing few test cases.

## Enhancements

* Error Logging Functionality is not implemented yet.
* Automapper and Autofaq can be used.
* The FilePath should be sent as body not as a parameter from the consumer app. Api needs to accept the post requests and the content from the body.

## Nice to have
* The file needs to be stored in AWS S3 bucket for public access.
* The web API can be hosted as AWS Lambda.

