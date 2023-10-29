namespace PlatformService.Options;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServicesSchema(configuration);

        return services;
    }
}
