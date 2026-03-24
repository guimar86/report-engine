using Domain.Interfaces;
using Microsoft.Playwright;
namespace Application.Services;

public class PdfService : IPdfService
{


    public async Task<byte[]> Generate(string html)
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

        var page = await browser.NewPageAsync();
        await page.EmulateMediaAsync(new PageEmulateMediaOptions
        {
            Media = Media.Screen
        });
        await page.SetContentAsync(html, new PageSetContentOptions
        {
            WaitUntil = WaitUntilState.Load
        });
        return await page.PdfAsync(new PagePdfOptions
        {
            Format = "A4",
            PrintBackground = true
        });
    }
}