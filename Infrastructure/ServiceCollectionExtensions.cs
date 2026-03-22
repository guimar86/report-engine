using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReportInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IReportRepository,ReportRepository>();
        services.AddDbContext<ReportDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ReportDb"));
        });
        return services;
    }
}