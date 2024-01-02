using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDS.Migrations
{
    public partial class ModifiedDonorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastDonationDate",
                table: "donor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDonationDate",
                table: "donor");
        }
    }
}
