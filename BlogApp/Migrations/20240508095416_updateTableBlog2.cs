using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    public partial class updateTableBlog2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_users_UserEmail",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Blogs",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_UserEmail",
                table: "Blogs",
                newName: "IX_Blogs_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_users_Email",
                table: "Blogs",
                column: "Email",
                principalTable: "users",
                principalColumn: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_users_Email",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Blogs",
                newName: "UserEmail");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_Email",
                table: "Blogs",
                newName: "IX_Blogs_UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_users_UserEmail",
                table: "Blogs",
                column: "UserEmail",
                principalTable: "users",
                principalColumn: "Email");
        }
    }
}
