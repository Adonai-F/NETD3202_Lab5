using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab5.Migrations
{
    public partial class Purchased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "purchasedId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    purchasedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<int>(nullable: false),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.purchasedId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_purchasedId",
                table: "Inventories",
                column: "purchasedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Orders_purchasedId",
                table: "Inventories",
                column: "purchasedId",
                principalTable: "Orders",
                principalColumn: "purchasedId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Orders_purchasedId",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_purchasedId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "purchasedId",
                table: "Inventories");
        }
    }
}
