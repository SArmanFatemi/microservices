using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers;

[Route("api/platforms")]
[ApiController]
public class PlatformsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlatformResponse>>> GetAll([FromServices] IPlatformRepository platformRepository, CancellationToken cancellationToken)
    {
        var platforms = await platformRepository.GetAllAsync(cancellationToken);

        return Ok(platforms.ToResponses());
    }

    [HttpGet("{id}", Name = nameof(GetById))]
    public async Task<ActionResult<PlatformResponse>> GetById([FromServices] IPlatformRepository platformRepository, int id, CancellationToken cancellationToken)
    {
        var platform = await platformRepository.GetByIdAsync(id, cancellationToken);
        if (platform is null) return NotFound();

        return platform.ToResponse();
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        [FromServices] IPlatformRepository platformRepository,
        [FromServices] ICommandDataClient commandDataClient,
        PlatformRequest request,
        CancellationToken cancellationToken)
    {
        var platform = request.ToModel();
        await platformRepository.CreateAsync(platform, cancellationToken);
        await platformRepository.SaveChangesAsync(cancellationToken);

        try
        {
            await commandDataClient.SendPlatformToCommand(request, cancellationToken);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"--> Could not send synchronously: {exception.Message}");
        }

        return CreatedAtRoute(nameof(GetById), new { id = platform.Id }, platform.ToResponse());
    }
}
