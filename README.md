# TestWebApplication
This project provides a ASP.NET web application, developed in .NET 6. The front-end is developed using HTML, CSS, and JavaScript with Bootstrap templates. The back-end is a ASP.NET Web API providing controllers to handle REST API endpoints. The Web application presents a web page containing an input and an output field. Users can provide textual input in the input field, which gets written to a local database upon clicking the `Submit` button. The output field displays the data written to the local database by Windows Form application instances.

## Installation
The prerequisites for running this application are:  
1. Download and install [Visual Studio 2022](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&passive=false&cid=2030).
2. Install `ASP.NET and web development` workload of Visual Studio 2022 in the default location.
3. Download [SQLite3 database](https://www.sqlite.org/2022/sqlite-tools-win32-x86-3400000.zip) which is used as a local database to store user inputs.
4. (Optional) Install [Docker Desktop](https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe?utm_source=docker&utm_medium=webreferral&utm_campaign=dd-smartbutton&utm_location=module) to run the web application using the docker image. 

## Build and Run using Visual Studio 2022
1. Download the database provided in the repository under `Database\Testdatabase.db`.
2. Open the `TestWebApplication2.sln` file given in the repository to view the source code for Web application.
3. Configure the `Dockerized` and `DatabasePath` keys in the `appsettings.json` file as per user's requirement.
 `Dockerized`: `true` indicates that the web application is being run from a docker container. `false` indicates that the web application is being run locally through Visual Studio.
  `DatabasePath`: indicates the path to the local SQLite database. A new database is provided in this repository under `Database\Testdatabase.db`.
4. `Program.cs`is the entry point for this application where `index.html` is configured as the default landing page.
5. Web application's default port number `80` can be changed by modifying the `applicationUrl` key in the `launchSettings.json`.
6. This solution is dependent on the NuGet packages: `System.Data.SQLite.Core 1.0.117` and `StyleCop.Analyzers 1.1.118`. Ensure that the package dependencies are resolved when clicking on `Build Solution` or `(Ctrl + Shift + B)`.
8. Launch the application by clicking on `Start without Debugging` or `(Ctrl + F5)`.
9. The Web application page should be visible by opening `http://localhost:80` in the browser upon a successful build as shown below:

<img src="images/TestWebApplication.png" width="100%" alt="Test Web Application">

## (or) Run using the docker image
1. Launch Docker Desktop, and ensure that it is running.
2. Pull the docker image for web application by running `docker pull poojananjunda/pooja_docker_images:latest` in command prompt.
3. Download the database provided in the repository under `Database\Testdatabase.db`.
4. To run the web application execute `docker run -d -p 80:80 -v "<path-to-database>":/database poojananjunda/pooja_docker_images:latest`. Replace `<path-to-database>` appropriately. 
5. The application can be launched by opening `http://localhost:80` in the browser.

<img src="images/TestWebApplication.png" width="100%" alt="Test Web Application">

## Application functionality
1. When starting the application for the first time, a table called `DataTable` is created, if it is not already present in the provided database.
2. User can enter textual input in the text box provided.
3. The input text and the value `WebApplication` is persisted in the `TextData` and `Sender` columns, respectively of the `DataTable`, upon clicking the `Submit` button.
4. The application keeps polling the `DataTable` to read the `TextData` sent from the Windows Form Application and display it in the output text box. 
5. Polling is done at regular intervals of 1 second in a non-blocking fashion through HTTP GET request from `index.html` using a JavaScript function.

## Contributors
For further assistance or support in maintaining the application, you may please contact Pooja Prasanna Nanjunda (poojananjunda1996@gmail.com). Any bugs or errors in the application can be notified to the contributor by raising issue requests.
