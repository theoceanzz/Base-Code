using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FINAL_INTERN.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesOfCar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__3214EC27F184C55A", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    NameOfRole = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3214EC27BB563027", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Years = table.Column<DateTime>(type: "date", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StockQuantit = table.Column<int>(type: "int", nullable: true, defaultValue: 5),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    img = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    alt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    CategoriesOfCar_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarInfos__3214EC27723BAFE4", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CarInfos__Catego__2C3393D0",
                        column: x => x.CategoriesOfCar_ID,
                        principalTable: "CategoriesOfCar",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    img = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    alt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    Role_ID = table.Column<int>(type: "int", nullable: false),
                    resetPasswordToken = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    resetTokenExpiry = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounts__3214EC2740A22C18", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Accounts__resetT__267ABA7A",
                        column: x => x.Role_ID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_ID = table.Column<int>(type: "int", nullable: false),
                    NameOfCustomer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    dates = table.Column<DateTime>(type: "datetime", nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__3214EC272AE933FE", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Orders__Account___2F10007B",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false),
                    Car_ID = table.Column<int>(type: "int", nullable: false),
                    NameOfCar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    total = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3214EC2722E0846C", x => x.ID);
                    table.ForeignKey(
                        name: "FK__OrderDeta__Accou__32E0915F",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Car_I__33D4B598",
                        column: x => x.Car_ID,
                        principalTable: "CarInfos",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__31EC6D26",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Role_ID",
                table: "Accounts",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CarInfos_CategoriesOfCar_ID",
                table: "CarInfos",
                column: "CategoriesOfCar_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Account_ID",
                table: "OrderDetails",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Car_ID",
                table: "OrderDetails",
                column: "Car_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Order_ID",
                table: "OrderDetails",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Account_ID",
                table: "Orders",
                column: "Account_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "CarInfos");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "CategoriesOfCar");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
