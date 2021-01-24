    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // Redirects all HTTP requests to HTTPS
        if (env.IsProduction())
        {
            app.UseRewriter(new RewriteOptions()
                .AddRedirectToHttpsPermanent());
        }
         ....
    }
