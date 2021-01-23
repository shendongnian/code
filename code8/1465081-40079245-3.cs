    public void ConfigureServices(IServiceCollection services)
     {
         services.AddMvc();
         //Add Cors support to the service
         services.AddCors();
    
         var policy = new Microsoft.AspNet.Cors.Core.CorsPolicy();
    
         policy.Headers.Add("*");    
         policy.Methods.Add("*");          
         policy.Origins.Add("*");
         policy.SupportsCredentials = true;
    
         services.ConfigureCors(x=>x.AddPolicy("AllPolicy", policy));
    
     }
    
    
     public void Configure(IApplicationBuilder app, IHostingEnvironment  env)
     {
         // Configure the HTTP request pipeline.
    
         app.UseStaticFiles();
         //Use the new policy globally
         app.UseCors("AllPolicy");
         // Add MVC to the request pipeline.
         app.UseMvc();
     }
