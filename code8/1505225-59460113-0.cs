using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
(...)
 public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
            });
        }
    }
**YourService.cs**
using Microsoft.AspNetCore.Mvc;
(...)
public class MyeasynetworkController : Controller
    {
        [HttpGet]
        public IActionResult Run()
        {
            
            return Ok("Im Working");
        }
    }
and edit your **static void Main(string[] args)**
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://+:5000")
                .UseStartup<Startup>()
                .Build();
            host.Run();
then open [http://localhost:5000/Myeasynetwork/Run][1] and you should see http status 200 response with plain text *Im Working*
  [1]: http://localhost:5000/Myeasynetwork/Run
