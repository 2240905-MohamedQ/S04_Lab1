using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZombieParty.Migrations
{
    /// <inheritdoc />
    public partial class AjoutHuntingLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HuntingLogId",
                table: "Zombies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HuntingLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zombies_HuntingLogId",
                table: "Zombies",
                column: "HuntingLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zombies_HuntingLogs_HuntingLogId",
                table: "Zombies",
                column: "HuntingLogId",
                principalTable: "HuntingLogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zombies_HuntingLogs_HuntingLogId",
                table: "Zombies");

            migrationBuilder.DropTable(
                name: "HuntingLogs");

            migrationBuilder.DropIndex(
                name: "IX_Zombies_HuntingLogId",
                table: "Zombies");

            migrationBuilder.DropColumn(
                name: "HuntingLogId",
                table: "Zombies");
        }
    }
}
