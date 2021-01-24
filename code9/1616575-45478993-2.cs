    using System;
    using System.Net;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    namespace WebApplication1
    {
        public class Startup
        {
            public AppSettings AppSettings;
            public static string Colour;
            public static string External;
            public static string HostName;    
            public static string Internal;
            public static string Test;
            public Startup(IHostingEnvironment hostingEnvironment)
            {
                var configurationBuilder = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("appsettings.json", true, true).AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true).AddEnvironmentVariables();
                Configuration = configurationBuilder.Build();                
                External = Configuration.GetConnectionString("External");
                Internal = Configuration.GetConnectionString("Internal");                
                Test = Configuration.GetConnectionString("Test");
            }
            public IConfigurationRoot Configuration { get; }
            public void ConfigureServices(IServiceCollection serviceCollection)
            {
                serviceCollection.AddMvc();
                serviceCollection.Configure<AppSettings>(appSettings =>
                {
                    HostName = Dns.GetHostName().ToLower();
                    switch (HostName)
                    {
                        case "external-domain":
                            appSettings.ConnectionString = External;                                                        
                            appSettings.Colour = "blue";
                            
                            break;
                        case "internal-domain":
                            appSettings.ConnectionString = Internal;                            
                            appSettings.Colour = "purple";                            
                            break;
                        default:                              
                            appSettings.ConnectionString = Test;                            
                            appSettings.Colour = "red";                            
                            break;
                    }
                });
            }
            
            public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
                if (hostingEnvironment.IsDevelopment())
                {
                    applicationBuilder.UseDeveloperExceptionPage();
                    applicationBuilder.UseBrowserLink();
                }
                else {
                    applicationBuilder.UseExceptionHandler("/Home/Error");
                }
                applicationBuilder.UseStaticFiles();
                applicationBuilder.UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    }
