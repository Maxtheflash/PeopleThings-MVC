PeopleThings MVC (ASP.NET MVC)

PeopleThings-MVC is a CRUD-based ASP.NET MVC application designed to manage People and Things using clean models, forms, validation, and Entity Framework-backed data storage.
It demonstrates core MVC fundamentals, database operations, layout structure, and Razor-based views.

## Features
CRUD for People
- First Name
- Last Name
- Age
- Email
- Validation rules
- Listing, adding, editing, deleting

CRUD for Things
- Item Name
- Category
- Description
- Ownership (optional relation)
- Listing, adding, editing, deleting

MVC Best Practices
- Strongly-typed models
- Form validation using DataAnnotations
- Razor views
- Clean controller routing
- TempData + ViewBag usage
- Proper layout and shared views

SQL Database Integration
- Entity Framework
- Migrations
- LocalDB or SQL Express

## Tech Stack
Language: C#
Framework: ASP.NET MVC
Database: SQL Server / LocalDB
Tools: Visual Studio, NuGet, GitHub
Frontend: HTML5, Razor, Bootstrap

## Project Structure
```
PeopleThingsMVC/
│
├── App_Data/
├── App_Start/
├── Content/
├── Controllers/
├── Models/
├── Properties/
├── Scripts/
├── Views/
│   ├── People/
│   ├── Things/
│   ├── Shared/
│   └── Home/
│
├── favicon.ico
├── Global.asax
├── Web.config
├── PeopleThingsMVC.csproj
└── PeopleThingsMVC.sln
```
## Future Enhancements
- Add People–Thing relationships (assign items to people)
- Add search and filter functions
- Add pagination
- Add authentication and roles

## Author
Branden Maxwell
Software Developer (.NET MVC | C# | SQL)
GitHub: https://github.com/Maxtheflash
