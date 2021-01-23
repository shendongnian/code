    public void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<IClaimsTransformer, MyClaimsTransformer>();
      services.AddMvc();
      services.AddDbContext<MyDbContext>(options => options.UseSqlServer(
          Configuration.GetConnectionString("MyConnStringSetting")
        ));
      (...)
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      app.UseClaimsTransformation(context =>
      {
        var transformer = context.Context.RequestServices.GetRequiredService<IClaimsTransformer>();
        return transformer.TransformAsync(context);
      });
      (...)
    }
