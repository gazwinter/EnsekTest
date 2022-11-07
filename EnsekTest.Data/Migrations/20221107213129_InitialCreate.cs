using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnsekTest.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounts__349DA5A63181EBD7", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "MeterReadings",
                columns: table => new
                {
                    MeterReadingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    MeterReadingDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    MeterReadValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MeterRea__AFB4FD9945351D10", x => x.MeterReadingId);
                    table.ForeignKey(
                        name: "FK_MeterReadings_Accounts",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1234, "Freya", "Test" },
                    { 1239, "Noddy", "Test" },
                    { 1240, "Archie", "Test" },
                    { 1241, "Lara", "Test" },
                    { 1242, "Tim", "Test" },
                    { 1243, "Graham", "Test" },
                    { 1244, "Tony", "Test" },
                    { 1245, "Neville", "Test" },
                    { 1246, "Jo", "Test" },
                    { 1247, "Jim", "Test" },
                    { 1248, "Pam", "Test" },
                    { 2233, "Barry", "Test" },
                    { 2344, "Tommy", "Test" },
                    { 2345, "Jerry", "Test" },
                    { 2346, "Ollie", "Test" },
                    { 2347, "Tara", "Test" },
                    { 2348, "Tammy", "Test" },
                    { 2349, "Simon", "Test" },
                    { 2350, "Colin", "Test" },
                    { 2351, "Gladys", "Test" },
                    { 2352, "Greg", "Test" },
                    { 2353, "Tony", "Test" },
                    { 2355, "Arthur", "Test" },
                    { 2356, "Craig", "Test" },
                    { 4534, "JOSH", "TEST" },
                    { 6776, "Laura", "Test" },
                    { 8766, "Sally", "Test" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_AccountId",
                table: "MeterReadings",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterReadings");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
