using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClassS00219971.Migrations
{
    /// <inheritdoc />
    public partial class InitialCustomerTableSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    CreditRating = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreditRating", "Name" },
                values: new object[,]
                {
                    { 1, "8 Johnstown Road, Cork", 200m, "Patricia McKenna" },
                    { 2, "Garden House Crowther Way, Dublin", 400m, "Helen Bennett" },
                    { 3, "1900 Oak St., Vancouver", 2000m, "Yoshi Tanami" },
                    { 4, "12 Orchestra Terrace, Dublin 20", 800m, "John Steel" },
                    { 5, "Rue Joseph-Bens 532, Brussels", 600m, "Catherine Dewey" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
