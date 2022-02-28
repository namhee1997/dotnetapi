using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<HangHoa> hangHoasdb { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }

        //kiểu 2: thêm khóa chính trong bảng db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("Getutcdate()");
                e.Property(e => e.NguoiNhan).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("DonHangChiTiet");
                e.HasKey(m => new { m.MaDh, m.MaHh });//2 khóa chính

                e.HasOne(m => m.DonHang)
                .WithMany(m => m.DonHangChiTiets)//lấy ra đơn hàng ct từ Dơn hàng
                .HasForeignKey(m => m.MaDh)//ĐẶT khóa ngọai
                .HasConstraintName("FK_DonHangChiTiet_DonHang");//ten khoas

                e.HasOne(m => m.HangHoa)
                .WithMany(m => m.DonHangChiTiets)//lấy ra đơn hàng ct từ Dơn hàng
                .HasForeignKey(m => m.MaDh)//ĐẶT khóa ngọai
                .HasConstraintName("FK_DonHangChiTiet_HangHoa");//ten khoas

            });
        }
    }
}
