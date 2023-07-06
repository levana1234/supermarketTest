using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTest.Migrations
{
    /// <inheritdoc />
    public partial class udaitepasworded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personals_markets_marcetPersonID",
                table: "personals");

            migrationBuilder.AddForeignKey(
                name: "FK_personals_markets_marcetPersonID",
                table: "personals",
                column: "marcetPersonID",
                principalTable: "markets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personals_markets_marcetPersonID",
                table: "personals");

            migrationBuilder.AddForeignKey(
                name: "FK_personals_markets_marcetPersonID",
                table: "personals",
                column: "marcetPersonID",
                principalTable: "markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
