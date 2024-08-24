# MinimalApiDemo

![Banner Animation](https://your-animation-url.com/banner.gif)

## Overview

MinimalApiDemo is a lightweight Web API built with ASP.NET Core using the minimal API approach. It provides a simple demonstration of how to create and configure APIs with minimal code.

![Overview Animation](https://your-animation-url.com/overview.gif)

## Features

- **Minimal API endpoints**
- **Basic CRUD operations**
- **In-memory data storage**

![Features Animation](https://your-animation-url.com/features.gif)

## Getting Started

### Prerequisites

- **.NET Core SDK** (version 6.0 or later)

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/maduradevDotNet/MinimalApiDemo.git
    ```

    ![Clone Repo Animation](https://your-animation-url.com/clone-repo.gif)

2. **Navigate to the project directory:**

    ```bash
    cd MinimalApiDemo
    ```

3. **Restore the project dependencies:**

    ```bash
    dotnet restore
    ```

4. **Run the application:**

    ```bash
    dotnet run
    ```

    ![Run App Animation](https://your-animation-url.com/run-app.gif)

## Usage

- **GET /api/items**  
  Retrieve a list of items.

- **GET /api/items/{id}**  
  Retrieve a specific item by ID.

- **POST /api/items**  
  Create a new item. Requires JSON payload.

- **PUT /api/items/{id}**  
  Update an existing item. Requires JSON payload.

- **DELETE /api/items/{id}**  
  Delete an item by ID.

![Usage Animation](https://your-animation-url.com/usage.gif)

## Example Requests

- **Get All Items**

    ```bash
    curl -X GET "https://localhost:5001/api/items"
    ```

- **Get Item by ID**

    ```bash
    curl -X GET "https://localhost:5001/api/items/1"
    ```

- **Create New Item**

    ```bash
    curl -X POST "https://localhost:5001/api/items" -H "Content-Type: application/json" -d '{"name": "NewItem"}'
    ```

- **Update Item**

    ```bash
    curl -X PUT "https://localhost:5001/api/items/1" -H "Content-Type: application/json" -d '{"name": "UpdatedItem"}'
    ```

- **Delete Item**

    ```bash
    curl -X DELETE "https://localhost:5001/api/items/1"
    ```

![Example Requests Animation](https://your-animation-url.com/example-requests.gif)

## Configuration

No additional configuration is required for the minimal API setup.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Create a Pull Request.

![Contributing Animation](https://your-animation-url.com/contributing.gif)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

![License Animation](https://your-animation-url.com/license.gif)
