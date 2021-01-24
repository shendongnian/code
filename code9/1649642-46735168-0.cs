    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        //...
        app.UseMvc(routes =>
        {
            //...
            routes.MapRoute(
                name: "paged",
                template: "{controller=Reviews}/{action=Index}/page/{page=1}");
        });
     }
