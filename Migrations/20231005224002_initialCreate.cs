using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorPagesZenSpaCh7.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicesID = table.Column<int>(type: "int", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Services_ServicesID",
                        column: x => x.ServicesID,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Classification", "Fee", "Name" },
                values: new object[,]
                {
                    { 1, "Full", 450.0, "Full-Day Treatment Package" },
                    { 2, "Half", 300.0, "Half-Day Treatment Package" },
                    { 3, "Two", 225.0, "Two-Hour Treatment Package" },
                    { 4, "One", 100.0, "One-Hour Treatment Package" },
                    { 5, "Other", 200.0, "Custom Treatment Package" },
                    { 6, "Cut", 45.0, "Haircut or Trim" },
                    { 7, "Color", 100.0, "Full Foil Color" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "ContactEmail", "Name", "ServicesID" },
                values: new object[,]
                {
                    { 1, "wilma@flint.net", "Wilma Flintstone", 1 },
                    { 2, "Barn@rubb.com", "Barney Rubble", 7 },
                    { 3, "betts@rubb.com", "Betty Rubble", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ServicesID",
                table: "Contacts",
                column: "ServicesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
