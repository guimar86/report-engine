using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ReportConfiguration: IEntityTypeConfiguration<ReportData>
{
    public void Configure(EntityTypeBuilder<ReportData> builder)
    {
        builder.ToTable("Reports");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Payload)
            .IsRequired()
            .HasColumnType("text");
        
    }
}