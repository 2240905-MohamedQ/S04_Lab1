using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZombieParty.Migrations
{
    /// <inheritdoc />
    public partial class AjoutRelationsHuntingLogsZombies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zombies_HuntingLogs_HuntingLogId",
                table: "Zombies");

            migrationBuilder.DropIndex(
                name: "IX_Zombies_HuntingLogId",
                table: "Zombies");

            migrationBuilder.DropColumn(
                name: "HuntingLogId",
                table: "Zombies");

            migrationBuilder.CreateTable(
                name: "HuntingLogZombie",
                columns: table => new
                {
                    HuntingLogsId = table.Column<int>(type: "int", nullable: false),
                    ZombiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingLogZombie", x => new { x.HuntingLogsId, x.ZombiesId });
                    table.ForeignKey(
                        name: "FK_HuntingLogZombie_HuntingLogs_HuntingLogsId",
                        column: x => x.HuntingLogsId,
                        principalTable: "HuntingLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HuntingLogZombie_Zombies_ZombiesId",
                        column: x => x.ZombiesId,
                        principalTable: "Zombies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HuntingLogZombie_ZombiesId",
                table: "HuntingLogZombie",
                column: "ZombiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuntingLogZombie");

            migrationBuilder.AddColumn<int>(
                name: "HuntingLogId",
                table: "Zombies",
                type: "int",
                nullable: true);

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
    }
}
