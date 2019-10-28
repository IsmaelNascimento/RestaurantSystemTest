using Microsoft.EntityFrameworkCore.Migrations;

namespace IsmaelsRestaurant.Migrations
{
    public partial class FixedTablePlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Plates",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Plates",
                newName: "Preco");
        }
    }
}
