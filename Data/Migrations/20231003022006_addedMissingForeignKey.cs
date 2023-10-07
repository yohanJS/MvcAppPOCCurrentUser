using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAppPOC.Data.Migrations
{
    public partial class addedMissingForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPrimaryInfo_AspNetUsers_ApplicationUserId",
                table: "UserPrimaryInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserPrimaryInfo_ApplicationUserId",
                table: "UserPrimaryInfo");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserPrimaryInfo");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPrimaryInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryInfo_UserId",
                table: "UserPrimaryInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrimaryInfo_AspNetUsers_UserId",
                table: "UserPrimaryInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPrimaryInfo_AspNetUsers_UserId",
                table: "UserPrimaryInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserPrimaryInfo_UserId",
                table: "UserPrimaryInfo");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPrimaryInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserPrimaryInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryInfo_ApplicationUserId",
                table: "UserPrimaryInfo",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrimaryInfo_AspNetUsers_ApplicationUserId",
                table: "UserPrimaryInfo",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
