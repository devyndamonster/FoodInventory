using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodInventory.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSomething : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequiredWeight",
                table: "RecipeToIngredients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiredWeight",
                table: "RecipeToIngredients");
        }
    }
}
