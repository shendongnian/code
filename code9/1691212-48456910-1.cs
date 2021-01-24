    public void Configure(IApplicationBuilder app)  
    {
        app.UseStaticFiles();
    
        //enable session before MVC
        app.UseSession();						<===
    
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
    }
