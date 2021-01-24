    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
    	app.UseMvc(routes =>
    	{
    		routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
    	});
    }
