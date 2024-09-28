using System.ComponentModel.DataAnnotations.Schema;

namespace FoodInventory.Models
{
    public record RecipeToIngredient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public int RequiredWeight { get; set; }

        [NotMapped]
        public string IngredientName { get; set; } = string.Empty;

    }
}
