using System.Text.Json;
using Application.Interfaces;
using Application.Services;
using Domain.Models;

namespace Application.Generators;

public class InvoiceReportGenerator : IReportGenerator
{
    private readonly TemplateService _template;
    private readonly PdfService _pdf;

    public string ReportId => "invoice";

    public async Task<byte[]> GenerateAsync(string json)
    {
        var model = JsonSerializer.Deserialize<InvoiceReport>(json);

        var html = await _template.RenderAsync(
            "Reports/Templates/invoice.sbn",
            model);

        return _pdf.Generate(html);
    }
}