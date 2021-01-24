    namespace DL.SO.Web.UI
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure ASP.NET Core Identity
            services.AddIdentitySecurityService(this.Configuration);
            ...
        }
    }
