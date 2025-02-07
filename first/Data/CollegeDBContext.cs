using first.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace first.Data
{
    public class CollegeDBContext : DbContext

    {
        public CollegeDBContext(DbContextOptions<CollegeDBContext> options):base(options)
        {
                
        }
        public DbSet<Student> Student { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());



            //Data Added to the Database With overriding the method OnModelCreating
/*
            modelBuilder.Entity<Student>().HasData(new List<Student>()
            // Data Added using Migration

            {
                new Student {
                    Id = 1,
                    StudentName = "Jaydip",
                    Email = "jay59@gmail.com",
                    Address = "Pune",
                    DOB = new DateTime(2002,01,01)
                }, new Student {
                    Id = 2,
                    StudentName = "Mahesh",
                    Email = "mahesh89@gmail.com",
                    Address = "Mumbai",
                    DOB = new DateTime(2001,03,11)
                },new Student {
                    Id = 3,
                    StudentName = "Sam",
                    Email = "sam75@gmail.com",
                    Address = "USA",
                    DOB = new DateTime(2004,04,07)
                }
            });

            //Configure the Schema of Tables
            modelBuilder.Entity<Student>(Entity =>
            {
                Entity.Property(n => n.StudentName).IsRequired();
                Entity.Property(n => n.Address).IsRequired().HasMaxLength(300);
                Entity.Property(n => n.Email).IsRequired();
                Entity.Property(n => n.DOB).IsRequired();

            });*/
        }
      


    }
}
