using Microsoft.AspNetCore.Mvc;

namespace AppVersioning.API.Controllers;
[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    public HomeController()
    {
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok("Welcome to App Version Manager!");
    }
}
