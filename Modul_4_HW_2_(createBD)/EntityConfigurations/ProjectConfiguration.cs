using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Modul_4_HW_2__createBD_.Entities;

namespace Modul_4_HW_2__createBD_.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(a => a.ProjectId);
            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            builder.Property(a => a.Budget).HasColumnName("Budget").HasColumnType("money").IsRequired();
            builder.Property(a => a.StartedDate).HasColumnName("StartedDate").HasColumnType("datetime2").IsRequired();
        }
    }
}