# It-Book-Manager

`It-Book-Manager` is an ASP.NET Core MVC (.NET 10) learning project for managing books with SQL Server LocalDB and Entity Framework Core (Code First).

## Stack

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core 10 + SQL Server provider
- SQL Server LocalDB (`BookManagerDB`)
- Bootstrap 5.3 + Razor Tag Helpers

## Assignment Compliance Summary (Sections 1-8, 10)

- MVC setup, conventional routing, shared layout, `_ViewStart`, `_ViewImports`, Home page and navigation are implemented.
- `Book` model fields are used in English (`Id`, `Title`, `Author`, `Genre`, `YearPublished`, `NumberOfPages`, `IsAvailable`, `Description`, `ImagePath`).
- Validation includes required `Title`, required `Author`, and `NumberOfPages > 0` (plus sensible additional checks).
- EF Core DbContext, SQL Server LocalDB connection, `DbSet<Book>`, and migrations are configured without reset.
- CRUD is implemented with Bootstrap UI:
  - Index renders Bootstrap cards with `Title`, `Author`, `Genre`, `YearPublished`, availability and action buttons.
  - Details loads by `Id` and shows book data plus cover image with fallback handling.
  - Create/Edit use GET + POST with server validation and antiforgery.
  - Delete uses confirmation + POST deletion (no delete on GET).
- Empty list handling and unknown `Id` handling are in place.

## Run Locally

1. Ensure SQL Server LocalDB is installed and available on Windows.
2. Run:

```bash
dotnet restore
dotnet run --project BookManager/BookManager.csproj
```

3. Open the shown URL, then use Home -> View Books.

## Manual Verification Steps (with at least 5 records)

1. Create five distinct records from `Books -> Add Book`.
2. Verify in `Books` overview that cards show title, author, genre, year, availability and action buttons.
3. Open Details for each record and verify all fields plus image/fallback behavior.
4. Edit one record and verify values are prepopulated and persisted.
5. Delete one record and verify confirmation page and POST deletion flow.
6. Submit invalid Create/Edit input (`Title` empty, `Author` empty, `NumberOfPages = 0`) and verify validation errors.
7. Validate unknown IDs by opening a nonexisting `Book/Detail/{id}` and confirming not found behavior.
