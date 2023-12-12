using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.ASSAPI.Migrations
{
    public partial class product_table_IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Product");
        }
    }
}
