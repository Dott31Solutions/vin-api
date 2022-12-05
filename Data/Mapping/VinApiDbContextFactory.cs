using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace VinApi31.Data.Mapping
{
    public class VinApiDbContextFactory : IDesignTimeDbContextFactory<VinApiDbContext>
    {
        public VinApiDbContext CreateDbContext(string[] args)
        {

            var configuration = BuildConfiguration();

            var connectionString = configuration.GetConnectionString(VinApiDbProperties.ConnectionStringName);

            var builder = new DbContextOptionsBuilder<VinApiDbContext>()
                .UseMySql(connectionString, ServerVersion.Parse(configuration.GetValue<string>("ServerVersion")) /*ServerVersion.AutoDetect(connectionString)*/);

            return new VinApiDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
