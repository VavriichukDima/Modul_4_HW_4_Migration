using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Modul_4_HW_2__createBD_.Entities;

namespace Modul_4_HW_2__createBD_.EntityConfigurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(p => p.OfficeId);
            builder.Property(p => p.OfficeId).HasColumnName("OfficeId").IsRequired();
            builder.Property(p => p.Title).HasColumnName("Title").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Location).HasColumnName("Location").HasMaxLength(100).IsRequired();
        }
    }
}
