using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers;


[Route("api/commands/platforms")]
[ApiController]
public class PlatformsController : ControllerBase
{
    [HttpPost]
    public ActionResult TestInbuondConnection()
    {
        Console.WriteLine("--> Inbound POST # Command Service");
        return Ok("Inbound test from Platforms Controller");
    }
}
