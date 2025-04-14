using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Jane", "Johnson" },
                    { 2, "Mike", "Black" },
                    { 3, "Lisa", "Kudrow" },
                    { 4, "Monica", "Geller" },
                    { 5, "Daniel", "Ronald" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 14, 10, 28, 30, 12, DateTimeKind.Local).AddTicks(9034), 1 },
                    { 2, 2, new DateTime(2025, 4, 14, 10, 28, 30, 13, DateTimeKind.Local).AddTicks(6793), 2 },
                    { 3, 3, new DateTime(2025, 4, 14, 10, 28, 30, 13, DateTimeKind.Local).AddTicks(6801), 3 },
                    { 4, 4, new DateTime(2025, 4, 14, 10, 28, 30, 13, DateTimeKind.Local).AddTicks(6802), 4 },
                    { 5, 5, new DateTime(2025, 4, 14, 10, 28, 30, 13, DateTimeKind.Local).AddTicks(6803), 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Discount", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 15.0, "T-Shirt", 59.0 },
                    { 2, 25.0, "Trousers", 119.0 },
                    { 3, 5.0, "Shirt", 89.0 },
                    { 4, 35.0, "Blouse", 69.0 },
                    { 5, 45.0, "Short", 79.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
