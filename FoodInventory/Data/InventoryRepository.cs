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
                        (Name, Weight, BestBy)
                    VALUES 
                        (@Name, @Weight, @BestBy);
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
                    Weight,
                    BestBy
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
                    SET Name = @Name, Weight = @Weight, BestBy = @BestBy
                    WHERE Id = @Id
                ";

            await connection.ExecuteAsync(query, ingredient);
        }
    }
}
