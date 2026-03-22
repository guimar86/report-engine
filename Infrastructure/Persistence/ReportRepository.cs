using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;


public class ReportRepository(ReportDbContext context) : IReportRepository
{
    public ReportData GetReportData(string id)
    {
        return context.Reports.AsNoTracking().FirstOrDefault(r => r.Id == id) ?? throw new KeyNotFoundException();
    }
}