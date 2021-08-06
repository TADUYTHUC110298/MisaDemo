using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MISA.CukCuk.Models
{
    public partial class MISADemoContex : DbContext
    {
        public MISADemoContex()
        {
        }

        public MISADemoContex(DbContextOptions<MISADemoContex> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Ethnic> Ethnic { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<ViewEmployee> ViewEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=host;port=3306;user=root;password='';database=MISADemo", x => x.ServerVersion("10.3.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasComment("Danh mục phòng ban");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DepartmentCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã phòng ban")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên phòng ban")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasComment("Mã phòng ban cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasComment("Bảng danh mục Nhân viên");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("FK_Employee_Department_DepartmentID");

                entity.HasIndex(e => e.EmployeeCode)
                    .HasName("UK_Employee_Employeecode")
                    .IsUnique();

                entity.HasIndex(e => e.FullName);

                entity.HasIndex(e => e.PositionId)
                    .HasName("FK_Employee_Position_PositionID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizebIdentityDate).HasColumnType("date");

                entity.Property(e => e.CitizebIdentityPlace)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nơi cấp chứng minh thư/ hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityCode)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số chứng minh thư")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo bản ghi");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasComment("Email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Họ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("Họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasComment("Giới tính (0-Nữ, 1- Nam, 2- Khác)");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Salary).HasComment("Mức lương");

                entity.Property(e => e.SelfTaxCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã số thuế cá nhân")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WorkState)
                    .HasColumnType("int(11)")
                    .HasComment("Tình trạng công việc (0- ĐÃ nghỉ việc, 1- Đang làm việc, 2- Đã nghỉ hưu)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Ethnic>(entity =>
            {
                entity.HasComment("Bảng danh mục dân tộc");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("EthnicID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EthnicName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasComment("Vị trí");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên vị trí")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ViewEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Employee");

                entity.Property(e => e.CitizebIdentityDate).HasColumnType("date");

                entity.Property(e => e.CitizebIdentityPlace)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nơi cấp chứng minh thư/ hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CitizenIdentityCode)
                    .HasColumnType("varchar(25)")
                    .HasComment("Số chứng minh thư")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo bản ghi");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.DepartmentCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã phòng ban")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DepartmentName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên phòng ban")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DepartmentParentId)
                    .HasColumnName("DepartmentParentID")
                    .HasComment("Mã phòng ban cha")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasComment("Email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Họ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("Họ và tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasComment("Giới tính (0-Nữ, 1- Nam, 2- Khác)");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PositionName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên vị trí")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Salary).HasComment("Mức lương");

                entity.Property(e => e.SelfTaxCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã số thuế cá nhân")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WorkState)
                    .HasColumnType("int(11)")
                    .HasComment("Tình trạng công việc (0- ĐÃ nghỉ việc, 1- Đang làm việc, 2- Đã nghỉ hưu)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
