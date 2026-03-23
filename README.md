# Recipe API

REST API built with ASP.NET (.NET 9) using EF Core and SQLite. Manages recipes and ingredients.

---

### Run the project
```bash
dotnet run
```


Listening to: http://localhost:5233


### Test the endpoints

 - Swagger: http://localhost:5233/swagger
 + Postman collection: `Postman/RecipeApi.postman_collection.json`

 ### Endpoints in this collection:

 - GET /api/recipes
 - GET /api/recipes/{id}
 - GET /api/recipes/{id}/ingredients
 - POST /api/recipes
 - PUT /api/recipes/{id}
 - DELETE /api/recipes/{id} - **Make sure to do this last**

 ---

 ### Database

 - Created via EF Core migrations with seed data
 - 1 Recipe: `Pasta`
 - 1 Ingredient: `Pasta, 200g`

 ### Reset the database:

 ```bash
 dotnet ef database drop
 dotnet ef database update
 ```


 