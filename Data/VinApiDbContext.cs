using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

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

    }
}
