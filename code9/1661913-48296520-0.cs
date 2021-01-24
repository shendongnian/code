    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.Use(async (context, next) => {
            context.Request.EnableRewind();
            await next();
        }
        ...
    });
