          public class Startup {
            public Startup(IHostingEnvironment env) {
              var builder = new ConfigurationBuilder()
                  .SetBasePath(env.ContentRootPath)
                  .AddEnvironmentVariables();
              Configuration = builder.Build();
            }
            private IHostingEnvironment CurrentEnvironment { get; set; }
            private IConfigurationRoot Configuration { get; }
            public void ConfigureServices(IServiceCollection services) {
              services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
              });
            }
            public void Configure(IApplicationBuilder app) {
              app.UseStaticFiles();
              app.UseMvc(routes => {
                routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
              });
            }
          }
