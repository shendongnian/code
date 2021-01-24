    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Primitives;
    
    namespace Sample.Proxy
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddLogging(options =>
                {
                    options.AddDebug();
                    options.AddConsole(console =>
                    {
                        console.IncludeScopes = true;
                    });
                });
    
                services.AddProxy(options =>
                {
                    options.MessageHandler = new HttpClientHandler
                    {
                        AllowAutoRedirect = false,
                        UseCookies = true 
                    };
    
                    options.PrepareRequest = (originalRequest, message) =>
                    {
                        var host = GetHeaderValue(originalRequest, "X-Forwarded-Host") ?? originalRequest.Host.Host;
                        var port = GetHeaderValue(originalRequest, "X-Forwarded-Port") ?? originalRequest.Host.Port.Value.ToString(CultureInfo.InvariantCulture);
                        var prefix = GetHeaderValue(originalRequest, "X-Forwarded-Prefix") ?? originalRequest.PathBase;
    
                        message.Headers.Add("X-Forwarded-Host", host);
                        if (!string.IsNullOrWhiteSpace(port)) message.Headers.Add("X-Forwarded-Port", port);
                        if (!string.IsNullOrWhiteSpace(prefix)) message.Headers.Add("X-Forwarded-Prefix", prefix);
    
                        return Task.FromResult(0);
                    };
                });
            }
    
            private static string GetHeaderValue(HttpRequest request, string headerName)
            {
                return request.Headers.TryGetValue(headerName, out StringValues list) ? list.FirstOrDefault() : null;
            }
    
            public void Configure(IApplicationBuilder app)
            {
                app.UseWebSockets()
                    .Map("/api", api => api.RunProxy(new Uri("http://localhost:8833")))
                    .Map("/image", api => api.RunProxy(new Uri("http://localhost:8844")))
                    .Map("/admin", api => api.RunProxy(new Uri("http://localhost:8822")))
                    .RunProxy(new Uri("http://localhost:8811"));
            }
    
            public static void Main(string[] args)
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
    
                host.Run();
            }
        }
    }
