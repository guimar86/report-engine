using System.Text.Json;
using Application.Configuration;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Options;

namespace Application.Generators;

public class InvoiceReportGenerator : IReportGenerator
{
    private readonly TemplateService _template;
    private readonly IPdfService _pdf;
    private readonly ReportSettings _reportSettings;

    /// <summary>
    /// Generate specific invoice report
    /// </summary>
    /// <param name="template"></param>
    /// <param name="pdf"></param>
    /// <param name="reportSettings"></param>
    public InvoiceReportGenerator(TemplateService template, IPdfService pdf, IOptions<ReportSettings> reportSettings)
    {
        _template = template;
        _pdf = pdf;
        _reportSettings = reportSettings.Value;
    }

    public string ReportId => "invoice";

    public async Task<byte[]> GenerateAsync(string json)
    {
        var model = JsonSerializer.Deserialize<InvoiceReport>(json) ?? throw new Exception("Invalid JSON for InvoiceReport");
        var html = await _template.RenderAsync(
            _reportSettings.Settings[ReportId].Path,
            model);

        return await _pdf.Generate(html);
    }
}