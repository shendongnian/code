    public void ConfigureServices(IServiceCollection services)
    {
         // Add framework services.
         services.AddMvc();
       // my other stuff that is not relevant in this post
         // Security
         services.AddTransient<CustomAuthorizationAttribute>();
     }
