    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
        ILoggerFactory loggerFactory)
    {
        //snip
        app.UseSignalR(routes =>
        {
            routes....... //Your routes here
        });
    }
