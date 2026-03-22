using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces;

/// <summary>
/// Report repositories
/// </summary>
public interface IReportRepository
{
    ReportData GetReportData(string id);
}