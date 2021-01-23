    public void ConfigureAuth(IAppBuilder app)
    {
        app.CreatePerOwinContext(ApplicationDbContext.Create);
        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        
        // register role manager
        app.CreatePerOwinContext<RoleManager<IdentityRole>>((o, c) => 
            new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(c.Get<ApplicationDbContext>())));
        // other codes here
    }
