    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }
    
        app.UseStaticFiles();
        if (!DatabaseInstalledMiddleware.IsDatabaseInstalled(Configuration))
            app.UseMiddleware<DatabaseInstalledMiddleware>();
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
    }
