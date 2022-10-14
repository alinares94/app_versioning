using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AppVersioning.API.Controllers;
[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    private readonly string _apiVersion;
    public HomeController(IConfiguration configuration)
    {
        _apiVersion = configuration.GetSection("ApiVersion").Value;
    }

    [HttpGet]
    public ActionResult<string> Version()
    {
        var result = $"<h2>Api Version {_apiVersion}</h2>";
        return Content(result, "text/html");
    }
}
