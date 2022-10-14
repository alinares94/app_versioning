using Microsoft.AspNetCore.Mvc;

namespace AppVersioning.API.Controllers;
[ApiController]
[Route("[controller]")]
public class AppVersioningController : ControllerBase
{
    private readonly IEnumerable<AppVersionDto> _settings;
    public AppVersioningController(IConfiguration configuration)
    {
        _settings = configuration.GetSection(AppVersionDto.SETTINGS_KEY).Get<List<AppVersionDto>>() ?? Enumerable.Empty<AppVersionDto>();
    }

    [HttpGet("IsValid/{key}/{version}")]
    public ActionResult<bool> Get(string key, string version)
    {
        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(version))
            return BadRequest();

        var minVersion = _settings.FirstOrDefault(x => x.Key.ToUpper().Equals(key.ToUpper()))?.MinVersion;
        if (string.IsNullOrEmpty(minVersion))
            return NotFound();

        return Ok(ConvertVersionToInt(version) >= ConvertVersionToInt(minVersion));
    }

    private int ConvertVersionToInt(string version)
    {
        string versioFormated = version.Replace(".", string.Empty);
        return int.TryParse(versioFormated, out int intVersion) ? intVersion : 0;
    }
}
