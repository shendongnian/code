    using Microsoft.AspNetCore.Builder;   // for IApplicationBuilder and FileServerOptions
    using Microsoft.AspNetCore.Hosting;  // for IHostingEnvironment
    using Microsoft.Extensions.DependencyInjection;  // for IServiceCollection
    
    namespace ApiCall
    {
        public class Startup
        {
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddCors();  // to be accesssed from external sites, i.e. outside the server
                // Add framework services.
                services.AddMvc();   // to use Controllers
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                    app.UseFileServer();  // to be accessed from files in the server inside wwwroot folde
                    app.UseCors(builder =>   // to be accesssed from external sites, i.e. outside the server
                            builder.AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod()
                                   .AllowCredentials()
                            );
    
                app.UseMvc();
            }
        }
    }
