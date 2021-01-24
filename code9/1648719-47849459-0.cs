    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>();
        services.AddAuthentication(
                v => {
                    v.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                    v.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                }).AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = "CLIENT ID";
                    googleOptions.ClientSecret = "CLIENT SECRET";
                });
        services.AddMvc();
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseAuthentication()
           .UseMvc();
    }
