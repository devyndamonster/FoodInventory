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
                        (Name)
                    VALUES 
                        (@Name);
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
                    Name 
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
    }
}
