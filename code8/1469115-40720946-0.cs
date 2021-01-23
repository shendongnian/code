    public void ConfigureAuth(IAppBuilder app)
    {
        // Add this reference
        app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
    }
