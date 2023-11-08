using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Walter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IpAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IpAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpAddress", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IpAddress",
                columns: new[] { "Id", "Address" },
                values: new object[] { 1, "0.0.0.0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IpAddress");
        }
    }
}
