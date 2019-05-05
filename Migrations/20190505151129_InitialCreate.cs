using Microsoft.EntityFrameworkCore.Migrations;

namespace TestMySqlDataMissingAutoIncrementAnnotation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Baz_Data = table.Column<int>(nullable: false),
                    BarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.BarId);
                });

            migrationBuilder.CreateTable(
                name: "Foos",
                columns: table => new
                {
                    FooId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Baz_Data = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.FooId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Foos");
        }
    }
}
