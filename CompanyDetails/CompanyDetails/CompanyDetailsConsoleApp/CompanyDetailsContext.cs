using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyDetailsConsoleApp
{
    public partial class CompanyDetailsContext : DbContext
    {
        public CompanyDetailsContext()
        {
        }

        public CompanyDetailsContext(DbContextOptions<CompanyDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server="";Database=CompanyDetails;user="";Password="";Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.Property(e => e.DeptId).ValueGeneratedNever();

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).ValueGeneratedNever();

                entity.Property(e => e.EmpEmail)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmpFname)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmpLname)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.SalaryId).ValueGeneratedNever();

                entity.Property(e => e.SalaryDate).HasColumnType("date");
            });
        }
    }
}
