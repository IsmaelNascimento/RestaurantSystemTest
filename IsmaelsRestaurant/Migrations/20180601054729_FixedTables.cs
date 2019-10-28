using Microsoft.EntityFrameworkCore.Migrations;

namespace IsmaelsRestaurant.Migrations
{
    public partial class FixedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plates_Restaurants_RestaurantId",
                table: "Plates");

            migrationBuilder.DropIndex(
                name: "IX_Plates_RestaurantId",
                table: "Plates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Plates_RestaurantId",
                table: "Plates",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plates_Restaurants_RestaurantId",
                table: "Plates",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
