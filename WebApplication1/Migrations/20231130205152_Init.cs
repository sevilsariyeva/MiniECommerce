using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Init : Migration
    {
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
                    { 1, 1, new DateTime(2023, 12, 1, 0, 51, 52, 589, DateTimeKind.Local).AddTicks(656), 1 },
                    { 2, 2, new DateTime(2023, 12, 1, 0, 51, 52, 589, DateTimeKind.Local).AddTicks(689), 2 },
                    { 3, 3, new DateTime(2023, 12, 1, 0, 51, 52, 589, DateTimeKind.Local).AddTicks(693), 3 },
                    { 4, 4, new DateTime(2023, 12, 1, 0, 51, 52, 589, DateTimeKind.Local).AddTicks(695), 4 },
                    { 5, 5, new DateTime(2023, 12, 1, 0, 51, 52, 589, DateTimeKind.Local).AddTicks(696), 5 }
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
