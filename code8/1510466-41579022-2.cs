    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization(x =>
        {
            // _env is of type IHostingEnvironment, which you can inject in
            // the ctor of Startup
            if (_env.IsDevelopment())
            {
                x.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAssertion(_ => true)
                    .Build();
            }
        });
    }
