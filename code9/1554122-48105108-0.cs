    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // Serve the files Default.htm, default.html, Index.htm, Index.html
        // by default (in this order), i.e., without having to explicitly qualify the URL.  
        app.UseDefaultFiles(); 
        // Enable static files to be served
        app.UseStaticFiles(); // Enable static files to be served
    }
