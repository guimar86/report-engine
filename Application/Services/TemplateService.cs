using Scriban;

namespace Application.Services;

public class TemplateService
{
    public async Task<string> RenderAsync(string templatePath, object model)
    {
        var templateText = await File.ReadAllTextAsync(templatePath);

        var template = Template.Parse(templateText);

        if (template.HasErrors)
            throw new Exception(template.Messages.ToString());

        var result = await template.RenderAsync(model, member => member.Name.ToLower());

        return result;
    }
}