using Microsoft.EntityFrameworkCore.Migrations;

namespace IsmaelsRestaurant.Migrations
{
    public partial class ApplyConstraints2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Plates",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Plates",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }
    }
}
