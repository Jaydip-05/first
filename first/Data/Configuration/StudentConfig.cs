using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace first.Data.Configuration
{
    public class StudentConfig : IEntityTypeConfiguration<Student> 
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");   // Table name 
            builder.HasKey(x => x.Id);    // Primary Key 


            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(n => n.StudentName).IsRequired();
            builder.Property(n => n.Address).IsRequired().HasMaxLength(300);
            builder.Property(n => n.Email).IsRequired();
            //builder.Property(n => n.DOB).IsRequired();

            builder.HasData(new List<Student>()
            // Data Added using Migration

            {
                new Student {
                    Id = 1,
                    StudentName = "Jaydip",
                    Email = "jay59@gmail.com",
                    Address = "Pune",
                    //DOB = new DateTime(2002,01,01)
                }, new Student {
                    Id = 2,
                    StudentName = "Mahesh",
                    Email = "mahesh89@gmail.com",
                    Address = "Mumbai",
                    //DOB = new DateTime(2001,03,11)
                },new Student {
                    Id = 3,
                    StudentName = "Sam",
                    Email = "sam75@gmail.com",
                    Address = "USA",
                    //DOB = new DateTime(2004,04,07)
                }
            });
        }
    }
}
