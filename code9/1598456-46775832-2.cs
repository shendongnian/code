    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<IUserStore<ApplicationUser>>(provider =>
      {
        return new InMemoryUserStore<ApplicationUser>();
      });
      services.AddIdentity<ApplicationUser>(Configuration)
              .AddDefaultTokenProviders();
    
      // Add application services.
      services.AddTransient<IEmailSender, EmailSender>();
    
      services.AddMvc();
    }
