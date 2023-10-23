using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatformService.Models;

namespace PlatformService.Persistence.Configurations
{
    public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.ToTable("Platforms");

            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Cost).IsRequired();
            builder.Property(e => e.Publisher).IsRequired();

            builder.HasData(new List<Platform>
            {
                new Platform(1, "dotnet", "Microsoft", "Free"),
                new Platform(2, "SQL Server Express", "Microsoft", "Free"),
                new Platform(3, "Kubernates", "CNCF", "Free"),
            });
        }
    }
}
