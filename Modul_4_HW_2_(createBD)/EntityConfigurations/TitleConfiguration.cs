using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Modul_4_HW_2__createBD_.Entities;

namespace Modul_4_HW_2__createBD_.EntityConfigurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(p => p.TitleId);
            builder.Property(p => p.TitleId).HasColumnName("TitleId").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            builder.HasMany(c => c.Employees)
                .WithOne(w => w.Title)
                .HasForeignKey(f => f.TitleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}