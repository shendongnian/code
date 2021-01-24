    using Microsoft.AspNetCore.Authentication.Cookies;
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication();
    }
    public void Configure(IApplicationBuilder app)
    {
         ...
         app.UseCookieAuthentication(new CookieAuthenticationOptions
         {
            AutomaticAuthenticate = true
         });
    }
