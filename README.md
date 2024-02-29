# WebAPI User Management

## Overview

WebAPI User Management is a .NET Core Web API that provides basic CRUD operations for managing user entities. It allows users to retrieve a list of users, get user details by ID, create, update, and delete users. The system also supports searching for users based on name and age.

## Project Components

- **User Entity:** Represents user data with fields such as Id, Name, Surname, and Age.
- **UserRepository:** Handles data access and storage using a static list.
- **UserService:** Implements business logic for user management operations.
- **UserController:** Exposes API endpoints for user-related actions.
- **DTOs (Data Transfer Objects):** Used for transferring data between layers.
- **AutoMapper:** Facilitates object-to-object mapping.

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- Visual Studio Code or Visual Studio (optional but recommended)

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/fukichime/WebAPI_User.git
