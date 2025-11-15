using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFistNET4.Migrations
{
    /// <inheritdoc />
    public partial class abc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QLKH");

            migrationBuilder.CreateTable(
                name: "LoaiKH",
                schema: "QLKH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiKH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKH", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                schema: "QLKH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiKHID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHang_LoaiKH_LoaiKHID",
                        column: x => x.LoaiKHID,
                        principalSchema: "QLKH",
                        principalTable: "LoaiKH",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_LoaiKHID",
                schema: "QLKH",
                table: "KhachHang",
                column: "LoaiKHID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHang",
                schema: "QLKH");

            migrationBuilder.DropTable(
                name: "LoaiKH",
                schema: "QLKH");
        }
    }
}
