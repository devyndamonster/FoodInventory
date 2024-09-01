namespace FoodInventory.Models
{
    public record Ingredient
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
