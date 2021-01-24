    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(this.ConnectionString));
    
    	...
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<Settings> lclog)
    {
    	...
    	
    	app.UseClientAuthentication();
    	app.UseMvc();
    }
