Startup.cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        // Other configuration code here...
        if (env.IsProduction())
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Host != new HostString("www.example.com"))
                {
                    var withDomain = "https://www.example.com" + context.Request.Path;
                    context.Response.Redirect(withDomain);
                }
                else if (!context.Request.IsHttps)
                {
                    var withHttps = "https://" + context.Request.Host + context.Request.Path;
                    context.Response.Redirect(withHttps);
                }
                else
                {
                    await next();
                }
            });
        }
    }
