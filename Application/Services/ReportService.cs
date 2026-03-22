using Application.Models;
using Domain.Interfaces;

namespace Application.Services;

public class ReportService
{
    private readonly ReportFactory _reportFactory;
    private readonly IReportRepository _reportRepository;

    public ReportService(ReportFactory reportFactory, IReportRepository reportRepository)
    {
        _reportFactory = reportFactory;
        _reportRepository = reportRepository;
    }

    public async Task<byte[]> GenerateReport(GenerateReportRequest request)
    {
        var dbData = _reportRepository.GetReportData(request.Id);
        var payload = dbData.Payload;
        var reportGenerator = _reportFactory.Get(request.Type);
        return await reportGenerator.GenerateAsync(payload);
    }
}