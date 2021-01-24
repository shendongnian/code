    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles(); // Requests handled by this middleware won't be redirected to HTTPS
    
        var options = new RewriteOptions()
           .AddRedirectToHttps();
    
        app.UseRewriter(options); // All requests that make it this far will be redirected from HTTP to HTTPS
        app.UseMvc(); // Requests guaranteed to be HTTPS
    }
