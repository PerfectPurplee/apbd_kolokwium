using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiKolokwium.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Order");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Client",
                newName: "IdClient");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Client",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Client",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    IdDiscount = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSubscription = table.Column<int>(type: "INTEGER", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateTo = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.IdDiscount);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    IdPayment = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSubscription = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.IdPayment);
                    table.ForeignKey(
                        name: "FK_Payment_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSale = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSubscription = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK_Sale_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    IdSubscription = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RenewalPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "numeric", precision: 10, scale: 2, nullable: false),
                    SaleIdSale = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.IdSubscription);
                    table.ForeignKey(
                        name: "FK_Subscription_Sale_SaleIdSale",
                        column: x => x.SaleIdSale,
                        principalTable: "Sale",
                        principalColumn: "IdSale");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdClient",
                table: "Payment",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdSubscription",
                table: "Payment",
                column: "IdSubscription");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdClient",
                table: "Sale",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdSubscription",
                table: "Sale",
                column: "IdSubscription");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_SaleIdSale",
                table: "Subscription",
                column: "SaleIdSale");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Subscription_IdSubscription",
                table: "Payment",
                column: "IdSubscription",
                principalTable: "Subscription",
                principalColumn: "IdSubscription",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Subscription_IdSubscription",
                table: "Sale",
                column: "IdSubscription",
                principalTable: "Subscription",
                principalColumn: "IdSubscription",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Subscription_IdSubscription",
                table: "Sale");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Client",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "numeric", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FulfilledAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Order",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Order", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Product_Order_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Doe" },
                    { 3, "Julie", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Apple", 3.4500000000000002 },
                    { 2, "Bananas", 5.5499999999999998 },
                    { 3, "Orange", 12.369999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Ongoing" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "ClientId", "CreatedAt", "FulfilledAt", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 1, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 3, 1, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 4, 2, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Product_Order",
                columns: new[] { "OrderId", "ProductId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 3, 1, 12 },
                    { 1, 2, 5 },
                    { 2, 2, 2 },
                    { 1, 3, 8 },
                    { 2, 3, 1 },
                    { 3, 3, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusId",
                table: "Order",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Order_OrderId",
                table: "Product_Order",
                column: "OrderId");
        }
    }
}
