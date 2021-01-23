    public static ApplicationDbContext Create(IdentityFactoryOptions<ApplicationDbContext> options, IOwinContext context)
    {
        // Do things here.
        string choice = context.Request.Cookies...;
        // Make sure that the cookie is correct.
        return new ApplicationDbContext(connectionName);
    }
