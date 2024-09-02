namespace FoodInventory.Models
{
    public record Ingredient
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int Weight { get; set; }

        public DateTime? BestBy { get; set; }
    }
}
