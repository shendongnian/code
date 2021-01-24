    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        // Make sure you call this before calling app.UseMvc()
    	app.UseCors(
    		options => options.WithOrigins("http://example.com").AllowAnyMethod()
    	);
    	app.UseMvc();
    }
