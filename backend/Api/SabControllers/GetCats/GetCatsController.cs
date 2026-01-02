using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzbWebDAV.Config;

namespace NzbWebDAV.Api.SabControllers.GetCats;

public class GetCatsController(HttpContext httpContext, ConfigManager configManager)
    : SabApiController.BaseController(httpContext, configManager)
{
    
    /// <summary>
    /// Mimic the sabnzbd get_cats api
    /// </summary>
    /// <returns>A valid sabnzbd cats object</returns>
    protected override Task<IActionResult> Handle()
    {
        var categories = configManager.GetApiCategories().Split(',')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();
        return Task.FromResult<IActionResult>(Ok(new { categories }));
    }
}