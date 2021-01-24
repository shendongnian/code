using Microsoft.AspNetCore.Server.IISIntegration;
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddAuthentication(IISDefaults.AuthenticationScheme);
        ...
    }
