using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Data.Migrations
{
    public partial class AddCostPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 19, 10, 55, 1, 509, DateTimeKind.Utc).AddTicks(2180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 19, 10, 36, 57, 201, DateTimeKind.Utc).AddTicks(7750));

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 19, 10, 36, 57, 201, DateTimeKind.Utc).AddTicks(7750),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 19, 10, 55, 1, 509, DateTimeKind.Utc).AddTicks(2180));
        }
    }
}
