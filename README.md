MinimalApiDemo
Overview
MinimalApiDemo is a lightweight Web API built with ASP.NET Core using the minimal API approach. It provides a simple demonstration of how to create and configure APIs with minimal code.

Features
Minimal API endpoints
Basic CRUD operations
In-memory data storage
Getting Started
Prerequisites
.NET Core SDK (version 6.0 or later)
Installation
Clone the repository:

bash
Copy code
git clone https://github.com/maduradevDotNet/MinimalApiDemo.git
Navigate to the project directory:

bash
Copy code
cd MinimalApiDemo
Restore the project dependencies:

bash
Copy code
dotnet restore
Run the application:

bash
Copy code
dotnet run
Usage
GET /api/items
Retrieve a list of items.

GET /api/items/{id}
Retrieve a specific item by ID.

POST /api/items
Create a new item. Requires JSON payload.

PUT /api/items/{id}
Update an existing item. Requires JSON payload.

DELETE /api/items/{id}
Delete an item by ID.

Example Requests
Get All Items

bash
Copy code
curl -X GET "https://localhost:5001/api/items"
Get Item by ID

bash
Copy code
curl -X GET "https://localhost:5001/api/items/1"
Create New Item

bash
Copy code
curl -X POST "https://localhost:5001/api/items" -H "Content-Type: application/json" -d '{"name": "NewItem"}'
Update Item

bash
Copy code
curl -X PUT "https://localhost:5001/api/items/1" -H "Content-Type: application/json" -d '{"name": "UpdatedItem"}'
Delete Item

bash
Copy code
curl -X DELETE "https://localhost:5001/api/items/1"
Configuration
No additional configuration is required for the minimal API setup.

Contributing
Fork the repository.
Create a new branch (git checkout -b feature/YourFeature).
Commit your changes (git commit -am 'Add new feature').
Push to the branch (git push origin feature/YourFeature).
Create a Pull Request.
License
This project is licensed under the MIT License - see the LICENSE file for details.
