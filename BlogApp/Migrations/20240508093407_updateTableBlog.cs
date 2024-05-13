using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    public partial class updateTableBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
