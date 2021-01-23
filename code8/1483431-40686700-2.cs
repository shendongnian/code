    // This method is not async out-of-the-box. Add the `async` modifier
    // but keep the return type as `void`, since the signature needs to
    // stay the same or you'll get a 500 error. We mark it as async because
    // the Identity methods are mostly async methods.
    public async void Configure(
        IApplicationBuilder app,
        IHostingEnvironment env,
        ILoggerFactory loggerFactory)
    {
        ...
        // Default ASP.NET Core route (generated out of the box)
        // I've included this so you know where to put your code!
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
        // Her, we call the code that setups up our roles and our first user.
        // These are methods added to the `Startup` class. We use the
        // IApplicationBuilder variable to pass in a User and Role
        // Manager instance from the application services.
        await CreateRoles(
            app.ApplicationServices
                .GetRequiredService<RoleManager<ApplicationRole>>());
        await ConfigureSiteAdmin(
            app.ApplicationServices
                .GetRequiredService<RoleManager<ApplicationRole>>(),
            app.ApplicationServices
                .GetRequiredService<UserManager<ApplicationUser>>()
        );
    }
