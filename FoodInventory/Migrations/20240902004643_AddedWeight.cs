using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodInventory.Migrations
{
    /// <inheritdoc />
    public partial class AddedWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BestBy",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Ingredients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Ingredients");
        }
    }
}
