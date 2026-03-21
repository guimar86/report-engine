namespace Application.Interfaces;

public interface IReportGenerator
{
    string ReportId { get; }
    Task<byte[]> GenerateAsync(string jsonPayload);
}