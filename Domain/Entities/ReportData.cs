using System;

namespace Domain.Entities;

public class Report
{
    public string Id { get; set; }
    public string Payload { get; set; }
    public DateTime CreatedAt { get; set; }
}