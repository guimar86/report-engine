using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;


public class ReportRepository(ReportDbContext context) : IReportRepository
{
    public ReportData GetReportData(string id)
    {

        return new ReportData
        {
            Id = id,
            Payload = $"{{\"Name\":\"John Doe\",\"Items\":[{{\"Name\":\"Laptop\",\"Price\":1200.50}},{{\"Name\":\"Mouse\",\"Price\":25.99}},{{\"Name\":\"Keyboard\",\"Price\":75.00}}],\"Total\":1301.49}}"
        };
        //return context.Reports.AsNoTracking().FirstOrDefault(r => r.Id == id) ?? throw new KeyNotFoundException();
    }
}