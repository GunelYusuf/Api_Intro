using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Data.Migrations
{
    public partial class ConfigTableAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 18, 11, 21, 36, 442, DateTimeKind.Utc).AddTicks(5550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 18, 10, 41, 16, 312, DateTimeKind.Utc).AddTicks(7730));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 18, 10, 41, 16, 312, DateTimeKind.Utc).AddTicks(7730),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 18, 11, 21, 36, 442, DateTimeKind.Utc).AddTicks(5550));
        }
    }
}
