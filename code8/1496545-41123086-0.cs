    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using Microsoft.Extensions.FileProviders;
    namespace CachingQuestion
    {
    public class Startup
    {
        static string CACHE_KEY = "CacheKey";
        public void ConfigureServices(IServiceCollection services)
        {
            //enabling the in memory cache 
            services.AddMemoryCache();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var fileProvider = new PhysicalFileProvider(env.ContentRootPath);
            app.Run(async context =>
            {
                //getting the cache object here
                var cache = context.RequestServices.GetService<IMemoryCache>();
                var greeting = cache.Get(CACHE_KEY) as string;
               
            });
        }
    }
    
     public class Program
     {
        public static void Main(string[] args)
        {
              var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
    }
