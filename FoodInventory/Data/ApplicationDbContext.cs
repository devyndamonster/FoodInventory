using FoodInventory.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodInventory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<IngredientType> IngredientTypes { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeToIngredient> RecipeToIngredients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
