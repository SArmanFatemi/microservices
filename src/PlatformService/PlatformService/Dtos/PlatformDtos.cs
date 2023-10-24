using PlatformService.Models;

namespace PlatformService.Dtos;

public record PlatformResponse(int Id, string Name, string Publisher, string Cost);

// TODO: We should implement validation later
public record PlatformRequest(string Name, string Publisher, string Cost);

public static class PlatformMappers
{
    public static PlatformResponse ToResponse(this Platform platform) =>
        new(platform.Id, platform.Name, platform.Publisher, platform.Cost);

    public static IEnumerable<PlatformResponse> ToResponses(this IEnumerable<Platform> platforms) =>
        platforms.Select(c => c.ToResponse());

    public static Platform ToModel(this PlatformRequest request, int? id = null) =>
        new(id ?? 0, request.Name, request.Publisher, request.Cost);
}