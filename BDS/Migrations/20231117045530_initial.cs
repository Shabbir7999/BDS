using Microsoft.EntityFrameworkCore.Migrations;

namespace BDS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "donor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    bloodtype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    residence = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "donor");
        }
    }
}
