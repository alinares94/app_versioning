using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AppVersioning.API.Controllers;
[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    private readonly string _apiVersion;
    private readonly ILogger _logger;
    public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
    {
        _apiVersion = configuration.GetSection("ApiVersion").Value;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<string> Version()
    {
        var result = $"<h2>Api Version {_apiVersion}</h2>";

        _logger.LogInformation(result);
        return Content(result, "text/html");
    }
}
