using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManagementPortal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Hours", "Name", "PayRate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 40m, "Luke Skywalker", 30m, new DateTime(2010, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human Resources Manager" },
                    { 2, 40m, "Leia Organa", 18m, new DateTime(2007, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Accountant" },
                    { 3, 35m, "Ezra Bridger", 22m, new DateTime(2018, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales Associate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
