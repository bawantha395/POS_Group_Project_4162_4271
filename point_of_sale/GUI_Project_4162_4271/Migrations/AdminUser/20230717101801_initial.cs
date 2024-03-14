using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GUI_Project_4162_4271.Migrations.AdminUser
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdminUserName = table.Column<string>(type: "TEXT", nullable: false),
                    AdminUserPassword = table.Column<int>(type: "INTEGER", nullable: false),
                    UserType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.AdminId);
                });

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "AdminId", "AdminUserName", "AdminUserPassword", "UserType" },
                values: new object[] { 1, "admin", 4162, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");
        }
    }
}
