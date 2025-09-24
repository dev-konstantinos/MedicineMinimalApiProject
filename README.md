# Minimal Medicine API

A **.NET Minimal API** for managing a home medicine inventory.  
This project demonstrates modern practices for building RESTful APIs with minimal setup.  

Since this API simulates a home medicine cabinet for personal use, some special criteria, such as the drug's batch number, have been deliberately omitted.
Instead, user-friendly logic has been added to prevent duplicate medications with the same name, dosage, and expiration date.

---

## Features

- **CRUD Operations**
  - `GET /api/medicine` – Retrieve all medicines.
  - `GET /api/medicine/{id}` – Retrieve a single medicine by ID.
  - `POST /api/medicine` – Add a new medicine.
  - `PUT /api/medicine/{id}` – Update an existing medicine.
  - `DELETE /api/medicine/{id}` – Remove a medicine by ID.

- **In-Memory Storage**
  - Medicines are stored in memory without a database.
  - Each medicine includes:
    - `Name`
    - `Dosage`
    - `Description`
    - `IsImportant`
    - `ExpDate`
    - `Quantity`

- **Validation with FluentValidation**
  - Ensures robust input checking.
  - Validates required fields, dosage formats, non-negative quantities, and future expiration dates.
  - Ensures unique combinations of `Name + Dosage + ExpDate`.

- **Structured Logging**
  - All CRUD operations and validation failures are logged using .NET `ILogger`.
  - Facilitates monitoring and debugging.

- **Swagger UI**
  - Interactive API documentation available at `/swagger`.

- **Extensibility**
  - Easily extendable to use persistent storage (EF Core).
  - Can integrate authentication/authorization in future.
  - Response DTOs or additional business logic can be added without breaking existing endpoints.

