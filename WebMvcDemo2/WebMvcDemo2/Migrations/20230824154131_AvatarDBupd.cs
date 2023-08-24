using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMvcDemo2.Migrations
{
    /// <inheritdoc />
    public partial class AvatarDBupd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Student");
        }
    }
}
