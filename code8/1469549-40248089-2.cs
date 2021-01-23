    public static ApplicationDbContext Create(IdentityFactoryOptions<ApplicationDbContext> options, IOwinContext context)
    {
        // Do things here.
        string connectionName = context.Request.Cookies...;
        return new ApplicationDbContext(connectionName);
    }
