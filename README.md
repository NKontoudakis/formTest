# FormTest - Enterprise N-Tier CRUD Application

A robust ASP.NET Core MVC application demonstrating N-Tier architecture, Role-Based Access Control (RBAC), and Entity Framework Core integration.

## 🏗️ Architecture

This solution follows a clean separation of concerns using a 3-tier structure:

* **FormTest.WebApp:** The presentation layer (ASP.NET Core MVC) handling user interactions, Controllers, and Views.
* **FormTest.Services:** The business logic layer containing Service classes and Interfaces.
* **FormTest.DataAccess:** The data persistence layer managing the SQL Server connection, EF Core Context, and Migrations.

## 🚀 Features

* **Secure Authentication:** Integrated ASP.NET Core Identity for user management.
* **Role-Based Authorization:**
    * **Admin:** Full access to Create, Read, Update, and List operations.
    * **Viewer:** Restricted Read-Only access (List and Details views).
* **Complete CRUD:** Full lifecycle management for Application Forms.
* **Data Seeding:** Automatic generation of Admin/Viewer roles and initial users on startup.
* **Pagination:** Optimized list views using LINQ `Skip`/`Take`.
* **Dynamic UI:** Usage of Tag Helpers and Enums for clean, maintainable Views.

## 🛠️ Tech Stack

* **Framework:** .NET 9.0
* **Type:** ASP.NET Core MVC
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core
* **Security:** ASP.NET Core Identity

## ⚙️ Getting Started

### Prerequisites
* .NET 9.0 SDK
* SQL Server (Local or Container)

### Installation

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/YOUR_USERNAME/FormTest.git](https://github.com/YOUR_USERNAME/FormTest.git)
    cd FormTest
    ```

2.  **Configure Database**
    Open `FormTest.WebApp/appsettings.json` and update the `DefaultConnection` string with your SQL Server credentials:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=FormTestDb;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
    }
    ```

3.  **Apply Migrations**
    Initialize the database schema:
    ```bash
    dotnet ef database update --project FormTest.DataAccess --startup-project FormTest.WebApp
    ```

4.  **Run the Application**
    ```bash
    dotnet run --project FormTest.WebApp
    ```

### 🔐 Default Login Credentials
The application includes a `DbSeeder` that runs on startup. You can use these accounts to test the roles:

| Role | Email | Password |
| :--- | :--- | :--- |
| **Admin** | `n.kontoudakis@mainsys.eu` | `xdR5$#@!!` |
| **Viewer** | `niko.ss@widnowslive.com` | `xdR5$#@!` |
| **Viewer** | *(Registered via UI)* | *(User defined)* |

*(Note: Check `FormTest.WebApp/Helpers/DbSeeder.cs` if you modified the default seed credentials).*
