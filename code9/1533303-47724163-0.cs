    public void Configure(IApplicationBuilder app, IHostingEnvironment env,  LoggerFactory loggerFactory,
    	ApplicationDbContext context)
     {
          context.Database.Migrate();
          ...
