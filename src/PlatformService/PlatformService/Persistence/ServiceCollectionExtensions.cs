using Microsoft.EntityFrameworkCore;

namespace PlatformService.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("PlatformService_InMemory"));

        return services;
    }
}
