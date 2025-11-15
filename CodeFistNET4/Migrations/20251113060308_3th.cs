using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFistNET4.Migrations
{
    /// <inheritdoc />
    public partial class _3th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idAccount",
                schema: "QLKH",
                table: "KhachHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_idAccount",
                schema: "QLKH",
                table: "KhachHang",
                column: "idAccount",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_accounts_idAccount",
                schema: "QLKH",
                table: "KhachHang",
                column: "idAccount",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_accounts_idAccount",
                schema: "QLKH",
                table: "KhachHang");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_idAccount",
                schema: "QLKH",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "idAccount",
                schema: "QLKH",
                table: "KhachHang");
        }
    }
}
