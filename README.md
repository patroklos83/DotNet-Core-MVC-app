
# Sample .Net MVC CRUD Application

An example template ASP.Net core MVC application for creating, updating, deleting entities.


## Requirements

For building and running the application you need:

-   [.Net framework 7 or newer](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
-  Visual Studio IDE
- [Docker 4.17.0 or newer ](https://www.docker.com/products/docker-desktop/)

## Case Study

A New agency requires a User friendly Interface, to view, create and edit Articles posted by the agency.

## Running the app

To run the web application there are 3 options. 

 1. Running the application in a Docker container. 
 2. Run from the the IDE.
 3. Run from the command line with the ASP.NET Core Runtime.

## Running the Application on a Docker container

Step 1. Run 'Build' command Docker Image
from the root directory

    docker build -t webapp:webapp

Step 2. Run Docker Image as a container
*from the root directory run command* 

    docker run -p 5000:80 -p 5001:443 webapp:webapp

Step 3. Access Application from browser

http://localhost:5000/Articles

## Running the Application from Command line 

Step 1. Go to root directory and execute the following line

    dotnet build "WebApplicationExample.csproj" -c Release -o /app/build

Step 2. From root directory run command

     dotnet publish "WebApplicationExample.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
Step 3. Go to /app/publish folder and run the web app

    dotnet WebApplicationExample.dll
    
Step 4. Access Application from browser

http://localhost:5000/Articles



![enter image description here](/Images/articles-summary.PNG)
![enter image description here](/Images/article-edit.PNG)



Fell free to grab a copy of this sample code, and play it yourself.
