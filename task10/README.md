## Prerequisites

- .NET SDK 10.0 or later
- `dotnet-ef` global tool

Install the EF Core tool once:

```bash
dotnet tool install --global dotnet-ef
```

## Run

From inside the `task10` folder:

```bash
dotnet restore
dotnet build
dotnet run
```

On startup the app automatically applies pending EF Core migrations and creates `products.db` in the working directory.

Once running, note the port from the console output (e.g. `http://localhost:5000`) and open:

- Swagger UI: `http://localhost:<port>/swagger`
- API root:   `http://localhost:<port>/api/products`

## Endpoints

| Method | Route                  | Description         |
|--------|------------------------|---------------------|
| GET    | `/api/products`        | List all products   |
| GET    | `/api/products/{id}`   | Get one product     |
| POST   | `/api/products`        | Create a product    |
| PUT    | `/api/products/{id}`   | Update a product    |
| DELETE | `/api/products/{id}`   | Delete a product    |

Request body for POST/PUT:

```json
{
  "name":  "Keyboard",
  "price": 1499.00,
  "stock": 25
}
```

## Migrations

The project ships with an `InitialCreate` migration. To create a new one after changing the model:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```
