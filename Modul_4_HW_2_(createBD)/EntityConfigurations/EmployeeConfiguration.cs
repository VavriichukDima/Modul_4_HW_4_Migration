using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Modul_4_HW_2__createBD_.Entities;

namespace Modul_4_HW_2__createBD_.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(p => p.EmployeeId);
            builder.Property(p => p.EmployeeId).HasColumnName("EmployeeId").IsRequired();
            builder.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(p => p.HiredDate).HasColumnName("HiredDate").IsRequired();
            builder.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");

            builder.HasOne(c => c.Office)
                .WithMany(s => s.Employee)
                .HasForeignKey(c => c.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}