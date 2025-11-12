using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFistNET4.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loaiKhuyenMais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiKM = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiKhuyenMais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "maKhuyenMais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    lkmID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maKhuyenMais", x => x.id);
                    table.ForeignKey(
                        name: "FK_maKhuyenMais_loaiKhuyenMais_lkmID",
                        column: x => x.lkmID,
                        principalTable: "loaiKhuyenMais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_maKhuyenMais_lkmID",
                table: "maKhuyenMais",
                column: "lkmID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "maKhuyenMais");

            migrationBuilder.DropTable(
                name: "loaiKhuyenMais");
        }
    }
}
