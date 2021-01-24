    using Microsoft.AspNetCore.Authentication.Cookies;
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCookieAuthentication();
        ...
    }
