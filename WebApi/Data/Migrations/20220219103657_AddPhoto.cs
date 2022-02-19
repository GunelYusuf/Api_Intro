using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Data.Migrations
{
    public partial class AddPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 19, 10, 36, 57, 201, DateTimeKind.Utc).AddTicks(7750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 18, 11, 21, 36, 442, DateTimeKind.Utc).AddTicks(5550));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 18, 11, 21, 36, 442, DateTimeKind.Utc).AddTicks(5550),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 19, 10, 36, 57, 201, DateTimeKind.Utc).AddTicks(7750));
        }
    }
}
