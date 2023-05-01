using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Orde.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ordering");

            migrationBuilder.CreateSequence(
                name: "buyerseq",
                schema: "Ordering",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "orderitemseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "orderseq",
                schema: "Ordering",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Buyers",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdentityGuid = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orderstatus",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderstatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _buyerId = table.Column<int>(type: "int", nullable: true),
                    _orderStatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _orderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Buyers__buyerId",
                        column: x => x._buyerId,
                        principalSchema: "Ordering",
                        principalTable: "Buyers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Orderstatus__orderStatusId",
                        column: x => x._orderStatusId,
                        principalSchema: "Ordering",
                        principalTable: "Orderstatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    _orderId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    _discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    _pictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _unitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    _units = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders__orderId",
                        column: x => x._orderId,
                        principalSchema: "Ordering",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_IdentityGuid",
                schema: "Ordering",
                table: "Buyers",
                column: "IdentityGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems__orderId",
                schema: "Ordering",
                table: "OrderItems",
                column: "_orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders__buyerId",
                schema: "Ordering",
                table: "Orders",
                column: "_buyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders__orderStatusId",
                schema: "Ordering",
                table: "Orders",
                column: "_orderStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "Buyers",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "Orderstatus",
                schema: "Ordering");

            migrationBuilder.DropSequence(
                name: "buyerseq",
                schema: "Ordering");

            migrationBuilder.DropSequence(
                name: "orderitemseq");

            migrationBuilder.DropSequence(
                name: "orderseq",
                schema: "Ordering");
        }
    }
}
