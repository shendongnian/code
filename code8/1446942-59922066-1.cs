    using Consul;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace WebApplication1
    {
        public static class AppExtensions
        {
            public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
                {
                    var address = configuration.GetValue<string>("http://localhost:8500");
                    consulConfig.Address = new Uri(address);
                }));
                return services;
            }
    
            public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
            {
                var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
                var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
                var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
    
   
                // var uri = new Uri(address);
                // Better approach should be used to set the below settings. I hard coded just to explain.
                var registration = new AgentServiceRegistration()
                {
                    ID = $"MyService",
                    Name = "WebApplication1",
                    Address = "localhost", //$"{uri.Host}",
                    Port = 57084  // uri.Port
                };
    
                logger.LogInformation("Registering with Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);
    
                lifetime.ApplicationStopping.Register(() =>
                {
                    logger.LogInformation("Unregistering from Consul");
                    consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                });
    
                return app;
            }
        }
    }
