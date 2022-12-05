using Microsoft.EntityFrameworkCore;
using VinApi31.Data.Mapping.Builders.Cars;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace VinApi31.Data
{
    public class VinApiDbContext: AbpDbContext<VinApiDbContext>
    {

        #region DbSet properties here
        #endregion

        #region Ctor
        
        public VinApiDbContext(DbContextOptions<VinApiDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Overrides

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Always call the base method
            base.OnModelCreating(builder);

            builder.ConfigureManufacturerEntity();
        }

        #endregion

    }
}
