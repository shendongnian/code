    using DL.SO.Services.Security.Entities;
    using DL.SO.Services.Security.Settings;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public static class ServiceCollectionExtensions
    {
        public static void AddIdentitySecurityService(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AppDbConnection");
            string assemblyNamespace = typeof(AppIdentityDbContext).Namespace;
            // AppIdentitySettings is one of the sections defined in appsettings.json
            // It might look like this:
            //   "AppIdentitySettings": {
            //     "User": {
            //         "RequireUniqueEmail": true,
            //         "AllowedUserNameCharacters": "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            //     },
            //     "Password": {
            //       "RequiredLength": 6,
            //       "RequireLowercase": true,
            //       "RequireUppercase": true,
            //       "RequireDigit": true,
            //       "RequireNonAlphanumeric": true
            //     }
            //  ...
            var settingsSection = configuration.GetSection("AppIdentitySettings");
            var settings = settingsSection.Get<AppIdentitySettings>();
            // Inject AppIdentitySettings
            services.Configure<AppIdentitySettings>(settingsSection);
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(connectionString, optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(assemblyNamespace)
                )
            );
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = settings.User.RequireUniqueEmail;
                // There are more options you can configure
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();
        }
    }
