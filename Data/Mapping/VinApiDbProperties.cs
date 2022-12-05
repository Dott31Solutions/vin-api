using Volo.Abp.Data;

namespace VinApi31.Data.Mapping
{
    public static class VinApiDbProperties
    {
        public static string DbTablePrefix { get; set; } = "va_";

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "Default";
    }
}
