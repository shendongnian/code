    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.OData;
    using Microsoft.AspNetCore.OData.Abstracts;
    using Microsoft.AspNetCore.OData.Builder;
    using Microsoft.AspNetCore.OData.Extensions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    
    namespace WebApplication1
    {
        public class Startup
        {
            public Startup(IHostingEnvironment env)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                Configuration = builder.Build();
            }
    
            public IConfigurationRoot Configuration { get; }
            
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
    
                /* ODATA part */
                services.AddOData();
                // the line below is used so that we the EdmModel is computed only once
                // we're not using the ODataOptions.ModelManager because it doesn't seemed plugged in
                services.AddSingleton<IODataModelManger, ODataModelManager>(DefineEdmModel);
            }
    
            private static ODataModelManager DefineEdmModel(IServiceProvider services)
            {
                var modelManager = new ODataModelManager();
    
                // you can add all the entities you need
                var builder = new ODataConventionModelBuilder();
                builder.EntitySet<MyEntity>(nameof(MyEntity));
                builder.EntityType<MyEntity>().HasKey(ai => ai.EntityID); // the call to HasKey is mandatory
                modelManager.AddModel(nameof(WebApplication1), builder.GetEdmModel());
    
                return modelManager;
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
    
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseBrowserLink();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
    
                app.UseStaticFiles();
    
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    }
