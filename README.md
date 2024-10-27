# Media Reviews Application

## Overview

This application allows users to add, view, edit, and delete reviews for various media, including movies, books, and games. 
It is built using ASP.NET Core Razor Pages and uses Entity Framework Core for data access with a PostgreSQL database.

## Architecture

- **Frontend**: ASP.NET Core Razor Pages with basic HTML and CSS for styling.
- **Backend**: C# with .NET 8, using Entity Framework Core to manage database interactions.
- **Database**: PostgreSQL to store review data.

### Instructions to Set Up and Run Locally

1. Clone the repository:

   git clone https://github.com/snehith777/MediaReviews.git  
   cd MediaReviews  
   
2. Open the project in Visual Studio 2022.
3. Install the necessary NuGet packages:
   
   Install-Package Microsoft.EntityFrameworkCore  
   Install-Package Microsoft.EntityFrameworkCore.Design  
   Install-Package Microsoft.EntityFrameworkCore.Tools  
   Install-Package Npgsql.EntityFrameworkCore.PostgreSQL  

4. Update the **appsettings.json** file with your PostgreSQL connection string.
   
5. Run the following commands in the Package Manager Console to create the database:  

    Add-Migration InitialCreate  
    Update-Database  

6. Run the application.



