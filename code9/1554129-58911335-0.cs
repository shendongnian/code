    // This code would be written in Startup.cs class for configuring the middleware components.
    
    
    
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
         
            app.UseDefaultFiles(); // This sets the default page redirection for the in-comming request
                app.UseStaticFiles(); // This serves the static files to the client.
     
            }
