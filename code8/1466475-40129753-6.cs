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
                    services.AddMvc().AddRazorOptions(options => {
                     var previous = options.CompilationCallback;
                     options.CompilationCallback = context => {
                       previous?.Invoke(context);
                       var refs = AppDomain.CurrentDomain.GetAssemblies()
                              .Where(x => !x.IsDynamic)
                              .Select(x => MetadataReference.CreateFromFile(x.Location))
                              .ToList();
                     context.Compilation = context.Compilation.AddReferences(refs);
                    };
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
