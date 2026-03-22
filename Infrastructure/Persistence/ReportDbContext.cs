using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ReportDbContext:DbContext
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options):base(options)
    {
        
    }

    public DbSet<ReportData> Reports => Set<ReportData>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReportDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    
}