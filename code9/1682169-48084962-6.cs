    public void ConfigureServices(IServiceCollection services)
    {
        services
        		.AddMvcCore()
        		.AddAuthorization(options =>
        		{
        				options.AddPolicy("AdminUser",
        				policy => policy.Requirements.Add(new AdminUserRequirement()));
        		});
        // More code here
    }
