using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System;
using Day1.Models;
using System.Reflection.Emit;

namespace Day1.Data
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7DT7JFM;Database=BanhaCompany;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder mB)
        {
            mB.Entity<Stud_Course>()
                .HasKey(x => new { x.StudentId, x.CourseId });

            mB.Entity<Stud_Course>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(sc=>sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            mB.Entity<Stud_Course>()
               .HasOne<Course>()
               .WithMany()
               .HasForeignKey(sc => sc.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Stud_Course> Stud_Courses { get; set; }
    }
}
