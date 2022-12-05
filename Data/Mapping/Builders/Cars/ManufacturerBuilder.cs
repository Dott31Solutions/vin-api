using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using VinApi31.Core.Domain;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace VinApi31.Data.Mapping.Builders.Cars
{
    public static class ManufacturerBuilder
    {
        public static void ConfigureManufacturerEntity(
            [NotNull] this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Manufacturer>(b =>
            {
                b.ToTable(VinApiDbProperties.DbTablePrefix + "Manufacturer", VinApiDbProperties.DbSchema);

                b.ConfigureByConvention();

                b.HasKey(x => x.Wmi);
                b.Property(x => x.Name).HasMaxLength(255).IsRequired();
                b.Property(x => x.Zone).HasMaxLength(255).IsRequired();
                b.Property(x => x.Country).HasMaxLength(255).IsRequired();

                b.ApplyObjectExtensionMappings();
            });

            builder.TryConfigureObjectExtensions<VinApiDbContext>();
        }
    }

}
