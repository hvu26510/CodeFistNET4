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

        public DbSet<KhachHang> khachHang { get; set; }
        public DbSet<LoaiKhachHang> loaiKhachHangs { get; set; }
        public DbSet<Account> accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(a => a.khachHang)
                .WithOne(kh => kh.Account)
                .HasForeignKey<KhachHang>(kh => kh.idAccount).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
