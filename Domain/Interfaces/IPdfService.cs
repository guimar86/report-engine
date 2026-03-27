using System;
using System.Threading.Tasks;

namespace Domain.Interfaces;

/// <summary>
/// Interface for PDF generation service
/// </summary>
public interface IPdfService
{
    /// <summary>
    /// Generates a PDF document from the provided HTML content and returns it as a byte array.
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    Task<byte[]> Generate(string html);
}
