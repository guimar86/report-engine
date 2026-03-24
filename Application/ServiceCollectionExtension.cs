using Application.Configuration;
using Application.Generators;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddReportGenerator(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ReportService>();
        services.AddScoped<ReportFactory>();
        services.AddScoped<TemplateService>();
        services.AddScoped<IPdfService, PdfService>();
        services.Configure<ReportSettings>(configuration.GetSection("ReportSettings"));
        services.AddTransient<IReportGenerator, InvoiceReportGenerator>();
        return services;
    }
}