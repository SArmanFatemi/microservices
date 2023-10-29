using Microsoft.Extensions.Options;
using PlatformService.Dtos;
using PlatformService.Options;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(PlatformRequest platform, CancellationToken cancellationToken);
}

internal class HttpCommanDataClient : ICommandDataClient
{
    private readonly HttpClient httpClient;
    private readonly ServiceSchema commandServiceSchema;
    private readonly string mediaType = "application/json";

    public HttpCommanDataClient(HttpClient httpClient, IOptionsSnapshot<ServiceSchema> options)
    {
        this.httpClient = httpClient;
        commandServiceSchema = options.Get(ServiceSchema.CommandService);
    }

    public async Task SendPlatformToCommand(PlatformRequest platform, CancellationToken cancellationToken)
    {
        var httpContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, mediaType);
        
        var response = await httpClient.PostAsync($"{commandServiceSchema.Url}/commands/platforms", httpContent);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("--> Sync POST to CommandService was OK!");
        }
        else
        {
            Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
        }
    }
}

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommandDataClient(this IServiceCollection services)
    {
        services.AddHttpClient<ICommandDataClient, HttpCommanDataClient>();
        return services;
    }
}