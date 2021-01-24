    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using WebApplication1.Entities;
    using WebApplication1.Entities.Contracts;
    
    namespace WebApplication1
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddScoped<IBusinessManager, BusinessManager>();
                services.AddScoped<IPayerManager, PayerManager>();
            }
        }
    }
