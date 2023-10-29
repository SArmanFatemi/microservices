namespace PlatformService.Options;

public sealed class ServiceSchema
{
    public const string CommandService = nameof(CommandService);

    public required string Url { get; set; }
}

internal static class ServicesSchemaServiceCollectionExtensions
{
    internal static IServiceCollection AddServicesSchema(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServiceSchema>(ServiceSchema.CommandService, configuration.GetSection($"{nameof(ServiceSchema)}:{ServiceSchema.CommandService}"));

        return services;
    }
}