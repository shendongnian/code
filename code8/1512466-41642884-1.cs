                  using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Threading.Tasks;
            using Microsoft.AspNetCore.Builder;
            using Microsoft.AspNetCore.Hosting;
            using Microsoft.Extensions.Configuration;
            using Microsoft.Extensions.DependencyInjection;
            using Microsoft.Extensions.Logging;
            using Microsoft.Extensions.Options;
            using System.Globalization;
            using Microsoft.AspNetCore.Localization;
            namespace coreweb
            {
                public class Startup
                {
                    public Startup(IHostingEnvironment env)
                    {
                        var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
                        if (env.IsDevelopment())
                        {
                            // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                            builder.AddApplicationInsightsSettings(developerMode: true);
                        }
                        Configuration = builder.Build();
                    }
                    public IConfigurationRoot Configuration { get; }
                    // This method gets called by the runtime. Use this method to add services to the container.
                    public void ConfigureServices(IServiceCollection services)
                    {
                        // ... previous configuration not shown
                        services.AddMvc();
                        services.Configure<RequestLocalizationOptions>(
                            opts =>
                            {
                                var supportedCultures = new[]
                                {
              
                            new CultureInfo("de-DE"),
                                };
                                opts.DefaultRequestCulture = new RequestCulture("de-DE");
                        // Formatting numbers, dates, etc.
                        opts.SupportedCultures = supportedCultures;
                        // UI strings that we have localized.
                        opts.SupportedUICultures = supportedCultures;
                            });
                    }
                    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
                    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
                    {
                        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                        loggerFactory.AddDebug();
                     //   app.UseApplicationInsightsRequestTelemetry();
                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseBrowserLink();
                        }
                        else
                        {
                            app.UseExceptionHandler("/Home/Error");
                        }
                      //  app.UseApplicationInsightsExceptionTelemetry();
                        app.UseStaticFiles();
                        var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
                        app.UseRequestLocalization(options.Value);
          
                        app.UseMvc(routes =>
                        {
                            routes.MapRoute(
                                name: "default",
                                template: "{controller=Home}/{action=Index}/{id?}");
                        });
                    }
                }
            }
