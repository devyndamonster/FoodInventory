using Dapper;
using FoodInventory.Models;
using Microsoft.Data.Sqlite;

namespace FoodInventory.Data
{
    public class InventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Ingredient> AddIngredient(Ingredient ingredient)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query =
            @"
                INSERT INTO Ingredients 
                (
                    Name, 
                    IngredientTypeId,
                    Weight, 
                    BestBy,
                    FrozenOn,
                    ThawedOn,
                    OpenedOn
                )
                VALUES 
                (
                    @Name, 
                    @IngredientTypeId,
                    @Weight, 
                    @BestBy,
                    @FrozenOn,
                    @ThawedOn,
                    @OpenedOn
                );

                SELECT 
                    last_insert_rowid() as Id;
            ";

            var id = await connection.QueryFirstOrDefaultAsync<int>(query, ingredient);

            return ingredient with { Id = id };
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query =
            @"
                SELECT 
                    Id, 
                    Name,
                    IngredientTypeId,
                    Weight,
                    BestBy,
                    FrozenOn,
                    ThawedOn,
                    OpenedOn
                FROM Ingredients
            ";

            return await connection.QueryAsync<Ingredient>(query);
        }

        public async Task DeleteIngredient(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query =
            @"
                DELETE FROM Ingredients
                WHERE Id = @Id
            ";

            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task UpdateIngredient(Ingredient ingredient)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query =
            @"
                UPDATE Ingredients
                SET 
                    Name = @Name, 
                    IngredientTypeId = @IngredientTypeId,
                    Weight = @Weight, 
                    BestBy = @BestBy,
                    FrozenOn = @FrozenOn,
                    ThawedOn = @ThawedOn,
                    OpenedOn = @OpenedOn
                WHERE Id = @Id
            ";

            await connection.ExecuteAsync(query, ingredient);
        }

        public async Task<IEnumerable<IngredientType>> GetIngredientTypes()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query =
            @"
                SELECT 
                    Id, 
                    Name
                FROM IngredientTypes
            ";

            return await connection.QueryAsync<IngredientType>(query);
        }

        public async Task<IngredientType> AddIngredientType(IngredientType ingredientType)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query =
            @"
                INSERT INTO IngredientTypes 
                (
                    Name
                )
                VALUES 
                (
                    @Name
                );

                SELECT 
                    last_insert_rowid() as Id;
            ";

            var id = await connection.QueryFirstOrDefaultAsync<int>(query, ingredientType);

            return ingredientType with { Id = id };
        }

        public async Task DeleteIngredientType(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query =
            @"
                DELETE FROM IngredientTypes
                WHERE Id = @Id
            ";

            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
