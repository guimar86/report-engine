using Application.Interfaces;

namespace Application.Services;

public class ReportFactory
{
    private readonly IEnumerable<IReportGenerator> _generators;

    public ReportFactory(IEnumerable<IReportGenerator> generators)
    {
        _generators = generators;
    }

    public IReportGenerator Get(string reportId)
        => _generators.First(x => x.ReportId.Equals(reportId, StringComparison.CurrentCultureIgnoreCase)) ?? throw new KeyNotFoundException();
}