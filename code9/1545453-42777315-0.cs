    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        string productType = Configuration["ProductType"];
        if (productType.Equals("G", StringComparison.OrdinalIgnoreCase))
        {
          app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional  },
                namespaces: new [] { "GLibrary.Controllers" });
            });
        }
        else if (productType.Equals("P", StringComparison.OrdinalIgnoreCase))
        {
          app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional  },
                namespaces: new [] { "PLibrary.Controllers" });
            });
        } 
    }
