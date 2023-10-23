namespace PlatformService.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IPlatformRepository, IPlatformRepository>();

        return services;
    }
}
