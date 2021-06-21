using Microsoft.EntityFrameworkCore.Migrations;

namespace MappingDemo.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustWithTotalClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustWithTotalClass",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSpent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
