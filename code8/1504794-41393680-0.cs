     using Microsoft.Owin;
    using Owin;
     public void Configuration(IAppBuilder app)
            {
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                ConfigureAuth(app);
              
            }
