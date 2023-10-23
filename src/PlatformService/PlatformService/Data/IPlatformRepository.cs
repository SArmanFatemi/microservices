using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepository
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);

    Task<IEnumerable<Platform>> GetAllAsync(CancellationToken cancellationToken);

    Task<Platform?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task CreateAsync(Platform platform, CancellationToken cancellationToken);
}
