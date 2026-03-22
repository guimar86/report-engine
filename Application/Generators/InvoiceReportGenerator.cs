using System.Text.Json;
using Application.Configuration;
using Application.Interfaces;
using Application.Services;
using Domain.Models;

namespace Application.Generators;

public class InvoiceReportGenerator : IReportGenerator
{
    private readonly TemplateService _template;
    private readonly PdfService _pdf;
    private readonly ReportSettings _reportSettings;

    /// <summary>
    /// Generate specific invoice report
    /// </summary>
    /// <param name="template"></param>
    /// <param name="pdf"></param>
    /// <param name="reportSetting"></param>
    public InvoiceReportGenerator(TemplateService template, PdfService pdf, ReportSettings reportSettings)
    {
        _template = template;
        _pdf = pdf;
        _reportSettings = reportSettings;
    }

    public string ReportId => "invoice";

    public async Task<byte[]> GenerateAsync(string json)
    {
        var model = JsonSerializer.Deserialize<InvoiceReport>(json) ?? throw new Exception("Invalid JSON for InvoiceReport");
        var html = await _template.RenderAsync(
            _reportSettings.Settings[ReportId].Path,
            model);

        return _pdf.Generate(html);
    }
}