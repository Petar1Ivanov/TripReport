using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripReport.Data.Migrations
{
    public partial class DurationID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Trip",
                newName: "DurationId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Duration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duration", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_DurationId",
                table: "Trip",
                column: "DurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Duration_DurationId",
                table: "Trip",
                column: "DurationId",
                principalTable: "Duration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Duration_DurationId",
                table: "Trip");

            migrationBuilder.DropTable(
                name: "Duration");

            migrationBuilder.DropIndex(
                name: "IX_Trip_DurationId",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trip");

            migrationBuilder.RenameColumn(
                name: "DurationId",
                table: "Trip",
                newName: "Duration");
        }
    }
}
