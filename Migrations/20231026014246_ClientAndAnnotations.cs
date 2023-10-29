using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorPagesZenSpaCh7.Migrations
{
    /// <inheritdoc />
    public partial class ClientAndAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    ServicesID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientServices_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientServices_Services_ServicesID",
                        column: x => x.ServicesID,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "City", "ConfirmPassword", "Country", "Email", "First Name", "Last Name", "Password", "Phone", "Zipcode", "State", "Username" },
                values: new object[,]
                {
                    { 1, "", "", "", "", "flo@schmoe.net", "Flo", "Schmoe", "FloSchmoe1234*", "", "", "", "Flo" },
                    { 2, "", "", "", "", "jojo@schmoe.net", "Jo", "Schmoe", "JoJoSchmoe1234?", "", "", "", "JoJo" },
                    { 3, "", "", "", "", "truly@schmoe.net", "Truly", "Schmoe", "Truly9876**", "", "", "", "Truly" }
                });

            migrationBuilder.InsertData(
                table: "ClientServices",
                columns: new[] { "ID", "ClientID", "Date", "ServicesID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 25, 21, 42, 46, 435, DateTimeKind.Local).AddTicks(7307), 1 },
                    { 2, 2, new DateTime(2023, 10, 25, 21, 42, 46, 435, DateTimeKind.Local).AddTicks(7385), 7 },
                    { 3, 1, new DateTime(2023, 10, 25, 21, 42, 46, 435, DateTimeKind.Local).AddTicks(7388), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ClientID",
                table: "ClientServices",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServicesID",
                table: "ClientServices",
                column: "ServicesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientServices");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
