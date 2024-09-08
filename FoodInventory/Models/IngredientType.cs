namespace FoodInventory.Models
{
    public record IngredientType
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
