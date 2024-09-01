using FoodInventory.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodInventory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
