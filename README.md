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

## Verification Results

- `dotnet restore BookManager/BookManager.csproj` — passed.
- `dotnet build BookManager/BookManager.csproj --no-restore` — passed with 0 warnings and 0 errors.
- No automated test project is included.
- Manual UI and database checks were not run: this environment is Linux and does not have SQL Server LocalDB available. The five-record CRUD flow, validation, unknown IDs, cover images and fallback, navigation, and LocalDB persistence therefore remain unverified here.

## Local Manual Verification Steps (with at least 5 records)

Run these checks on Windows with SQL Server LocalDB installed and available:

1. Start the app using the instructions above and navigate from Home to `Books`.
2. Create five distinct records from `Books -> Add Book`.
3. Verify navigation between Home, the books overview, and each book's Details, Edit, and Delete pages.
4. Verify the overview cards show title, author, genre, year, availability, and action buttons.
5. Open Details for each record and verify all fields, a working cover image, and the fallback for a missing or broken image.
6. Edit one record and verify its values are prepopulated and the changes persist after reloading.
7. Delete one record and verify the confirmation page and POST deletion flow.
8. Submit invalid Create/Edit input (`Title` empty, `Author` empty, `NumberOfPages = 0`) and verify validation errors.
9. Open a nonexisting `Book/Detail/{id}` and confirm not found behavior.
10. Restart the app and verify the remaining records are still stored in LocalDB.
