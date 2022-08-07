using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripReport.Data.Migrations
{
    public partial class DurationField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Payment_PaymentId",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Trip");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Payment_PaymentId",
                table: "Trip",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Payment_PaymentId",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Trip");

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "Trip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Payment_PaymentId",
                table: "Trip",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
