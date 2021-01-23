    public void ConfigureServices(IServiceCollection services)
    {
      // add the authentication dependencies
      services.AddAuthentication();
    }
    public void Configure(IApplicationBuilder app)
    {
      app.UseJwtBearerAuthentication(new JwtBearerOptions
      {
         // configure your JWT authentication here
      });
    }
