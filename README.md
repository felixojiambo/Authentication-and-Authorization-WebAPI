# Authentication and Authorization Web API

This project is an ASP.NET Core Web API for managing user authentication and authorization. It leverages JWT (JSON Web Tokens) for securing API endpoints and supports operations such as user registration, login, password reset, role management, and token refresh.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- Identity Framework
- JWT (JSON Web Tokens)
- RestSharp

## Features

- User Registration
- User Login
- Password Reset
- Role Management
- JWT Authentication
- Token Refresh

## Getting Started

### Prerequisites

- .NET 7 SDK
- SQL Server or any other database supported by Entity Framework Core

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/felixojiambo/Authentication-and-Authorization-WebAPI.git
   ```
2. Navigate to the project directory:
   ```bash
   cd Authentication-and-Authorization-WebAPI
   ```
3. Install the dependencies:
   ```bash
   dotnet restore
   ```

### Configuration

Configure the `appsettings.json` with your database connection string and JWT settings:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionString"
  },
  "JWTSetting": {
    "securityKey": "YourSecurityKey",
    "validIssuer": "YourIssuer",
    "validAudience": "YourAudience",
    "RefreshTokenValidityIn": 60
  },
  "MailSettings": {
    "Mail": "mailtrap@demomailtrap.com",
    "DisplayName": "Mailtrap",
    "Password": "YourPassword",
    "Host": "smtp.mailtrap.io",
    "Port": 587
  }
}
```

### Database Migration

Apply the database migrations to set up the database schema:

```bash
dotnet ef database update
```

### Running the Application

Start the application:

```bash
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`.

## API Endpoints

### Account Controller

#### Register

Registers a new user.

- **URL**: `/api/account/register`
- **Method**: POST
- **Body**:
  ```json
  {
    "email": "user@example.com",
    "fullName": "John Doe",
    "password": "password123",
    "roles": ["User"]
  }
  ```

#### Login

Logs in a user and returns a JWT token.

- **URL**: `/api/account/login`
- **Method**: POST
- **Body**:
  ```json
  {
    "email": "user@example.com",
    "password": "password123"
  }
  ```

#### Forgot Password

Sends a password reset link to the specified email.

- **URL**: `/api/account/forgot-password`
- **Method**: POST
- **Body**:
  ```json
  {
    "email": "user@example.com"
  }
  ```

#### Reset Password

Resets the user's password based on the received token.

- **URL**: `/api/account/reset-password`
- **Method**: POST
- **Body**:
  ```json
  {
    "email": "user@example.com",
    "token": "reset-token",
    "newPassword": "newpassword123"
  }
  ```

#### Change Password

Allows the authenticated user to change their password.

- **URL**: `/api/account/change-password`
- **Method**: POST
- **Body**:
  ```json
  {
    "email": "user@example.com",
    "currentPassword": "oldpassword123",
    "newPassword": "newpassword123"
  }
  ```

#### Refresh Token

Refreshes the user's authentication token.

- **URL**: `/api/account/refresh-token`
- **Method**: POST
- **Body**:
  ```json
  {
    "email": "user@example.com",
    "token": "current-token",
    "refreshToken": "refresh-token"
  }
  ```

### Roles Controller

#### Create Role

Creates a new role.

- **URL**: `/api/roles`
- **Method**: POST
- **Body**:
  ```json
  {
    "roleName": "Admin"
  }
  ```

#### Get Roles

Fetches all roles with the total number of users in each role.

- **URL**: `/api/roles`
- **Method**: GET

#### Delete Role

Deletes a role by its ID.

- **URL**: `/api/roles/{id}`
- **Method**: DELETE

#### Assign Role

Assigns a role to a user.

- **URL**: `/api/roles/assign`
- **Method**: POST
- **Body**:
  ```json
  {
    "userId": "user-id",
    "roleId": "role-id"
  }
  ```

## Security Considerations

- Ensure that the JWT secret key is stored securely and is not exposed in the source code.
- Use HTTPS to encrypt data in transit.
- Implement proper error handling to manage failed authentication attempts gracefully.

## Contributing

Contributions to this project are welcome. Please review the existing codebase and submit pull requests for enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for more information.
