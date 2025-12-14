using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Villa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingthedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfBedrooms = table.Column<int>(type: "int", nullable: false),
                    NumberOfBathrooms = table.Column<int>(type: "int", nullable: false),
                    HasSwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedAt", "Description", "HasSwimmingPool", "ImageUrl", "Location", "Name", "NumberOfBathrooms", "NumberOfBedrooms", "PricePerNight", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 14, 10, 1, 32, 707, DateTimeKind.Utc).AddTicks(987), "A beautiful villa with stunning ocean views.", true, "https://example.com/images/oceanview_retreat.jpg", "Malibu, CA", "Oceanview Retreat", 3, 4, 750.00m, null },
                    { 2, new DateTime(2025, 12, 14, 10, 1, 32, 707, DateTimeKind.Utc).AddTicks(1079), "Cozy villa nestled in the mountains, perfect for a winter getaway.", false, "https://example.com/images/mountain_escape.jpg", "Aspen, CO", "Mountain Escape", 2, 3, 600.00m, null },
                    { 3, new DateTime(2025, 12, 14, 10, 1, 32, 707, DateTimeKind.Utc).AddTicks(1081), "Modern villa located in the heart of the city with breathtaking skyline views.", false, "https://example.com/images/city_lights_villa.jpg", "New York, NY", "City Lights Villa", 2, 2, 850.00m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
