using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using PlatformService.Persistence;

namespace PlatformService.Data;

public class PlatformRepository : IPlatformRepository
{
    private readonly DatabaseContext databaseContext;

    public PlatformRepository(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public async Task CreateAsync(Platform platform, CancellationToken cancellationToken) =>
        await databaseContext.Platforms.AddAsync(platform, cancellationToken);

    public async Task<IEnumerable<Platform>> GetAllAsync(CancellationToken cancellationToken) =>
        await databaseContext.Platforms.ToListAsync(cancellationToken);
    

    public async Task<Platform?> GetByIdAsync(int id, CancellationToken cancellationToken) =>
        await databaseContext.Platforms.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken) =>
        await databaseContext.SaveChangesAsync(cancellationToken) >= 0;
}
