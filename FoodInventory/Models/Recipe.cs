using System.ComponentModel.DataAnnotations.Schema;

namespace FoodInventory.Models
{
    public record Recipe
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        [NotMapped]
        public List<RecipeToIngredient> Ingredients { get; set; } = [];
    }
}
