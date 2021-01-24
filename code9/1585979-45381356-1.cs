    using System;
    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    namespace AntiForgeryStrategiesCore
    {
        // ...
        public class Startup
        {
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddSingleton<IAntiforgeryAdditionalDataProvider, SingleTokenAntiforgeryAdditionalDataProvider>();
                // ...
            }
        }
    
        // ...
    }
   
