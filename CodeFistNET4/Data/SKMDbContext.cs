using CodeFistNET4.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CodeFistNET4.Data
{
    public class SKMDbContext : DbContext
    {
        public SKMDbContext(DbContextOptions<SKMDbContext> options) : base(options) {
        
        }

        public DbSet<MaKhuyenMai> maKhuyenMais { get; set; }
        public DbSet<LoaiKhuyenMai> loaiKhuyenMais { get; set; }
    }
}
