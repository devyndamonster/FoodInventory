namespace FoodInventory.Models
{
    public record Ingredient
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int? IngredientTypeId { get; set; }

        public int Weight { get; set; }

        public DateTime? BestBy { get; set; }

        public DateTime? FrozenOn { get; set; }

        public DateTime? ThawedOn { get; set; }

        public DateTime? OpenedOn { get; set; }

    }
}
