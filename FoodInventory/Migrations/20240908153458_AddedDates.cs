using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodInventory.Migrations
{
    /// <inheritdoc />
    public partial class AddedDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FrozenOn",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenedOn",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThawedOn",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrozenOn",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OpenedOn",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "ThawedOn",
                table: "Ingredients");
        }
    }
}
