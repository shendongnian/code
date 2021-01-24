    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        //For serving index.html on baseurl - this can we done in AppNancyModule aswell: Get("/", _ => View["index"]);
        app.UseDefaultFiles();
    
        app.UseStaticFiles();
    
        loggerFactory.AddNLog();
    
        app.AddNLogWeb();
    
        app.UseOwin(x => x.UseNancy(new NancyOptions
        {
            Bootstrapper = new Bootstrapper(app, env)
        }));
    }
