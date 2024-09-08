namespace FoodInventory.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
