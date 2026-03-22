namespace Application.Configuration;

public class ReportSetting
{
    public required string Path { get; set; }
}

public sealed class ReportSettings
{
    public Dictionary<string, ReportSetting> Settings { get; init; } = new();
}