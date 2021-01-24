    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; private set; }
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services) {
            // Add MVC, Authorization, etc.
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
        }
    }
