using Microsoft.EntityFrameworkCore.Migrations;

namespace IsmaelsRestaurant.Migrations
{
    public partial class SeedingDatabaseCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Restaurants (Name) VALUES ('Restaurant1')");
            migrationBuilder.Sql("INSERT INTO Restaurants (Name) VALUES ('Restaurant2')");
            migrationBuilder.Sql("INSERT INTO Restaurants (Name) VALUES ('Restaurant3')");

            migrationBuilder.Sql("INSERT INTO Plates (Name, Preco, RestaurantId) VALUES ('Plate1', 1, (SELECT id FROM Restaurants WHERE Name = 'Restaurant1'))");
            migrationBuilder.Sql("INSERT INTO Plates (Name, Preco, RestaurantId) VALUES ('Plate2', 31, (SELECT id FROM Restaurants WHERE Name = 'Restaurant2'))");
            migrationBuilder.Sql("INSERT INTO Plates (Name, Preco, RestaurantId) VALUES ('Plate3', 15, (SELECT id FROM Restaurants WHERE Name = 'Restaurant3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Plates WHERE Name IN ('Plate1', 'Plate2', 'Plate3')");
        }
    }
}