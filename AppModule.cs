using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Swashbuckle;
using Microsoft.OpenApi.Models;
using VinApi31.Data;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VinApi31
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule), // Add dependency to ABP Autofac module
        typeof(AbpEntityFrameworkCoreMySQLModule), // Add dependency to ABP Entity Framework module
        typeof(AbpSwashbuckleModule) // <-- Add module dependency like that
    )]
    public class AppModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Vin31 API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });

            ConfigureEfCore(context);
        }

        private void ConfigureEfCore(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<VinApiDbContext>(options =>
            {
                /* You can remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots
                 * Documentation: https://docs.abp.io/en/abp/latest/Entity-Framework-Core#add-default-repositories
                 */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(configurationContext =>
                {
                    configurationContext.UseMySQL();
                    // configurationContext.DbContextOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });
            });

        }
    }

}
