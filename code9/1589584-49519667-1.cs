    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseMiddleware(typeof(CorsMiddleware));
      // ... other middleware inclusion such as ErrorHandling, Caching, etc
      app.UseMvc();
    }
