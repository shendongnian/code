     public void ConfigureServices(IServiceCollection services)
        {
     
            services.AddIdentityServer().
                    .AddProfileService<ProfileService>();
    }
