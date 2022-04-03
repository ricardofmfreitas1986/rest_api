using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicationRESTApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Medication",
                columns: new[] { "Id", "CreationDate", "Name", "Quantity" },
                values: new object[] { new Guid("1a3d7301-c1e1-4650-ae96-ac83b19a9209"), new DateTime(2022, 4, 3, 17, 50, 47, 925, DateTimeKind.Utc).AddTicks(9003), "Aspirina", 2 });

            migrationBuilder.InsertData(
                table: "Medication",
                columns: new[] { "Id", "CreationDate", "Name", "Quantity" },
                values: new object[] { new Guid("90ba61b2-fff4-48f0-b260-3588ac0bf808"), new DateTime(2022, 4, 3, 17, 50, 47, 925, DateTimeKind.Utc).AddTicks(9007), "Voltaren", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medication");
        }
    }
}
