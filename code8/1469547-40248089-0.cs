app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
    public static ApplicationDbContext Create(IdentityFactoryOptions<ApplicationDbContext> options, IOwinContext context)
    {
        // Do things here.
        string connectionString = context.Request.Cookies...;
        return new ApplicationDbContext(connectionString);
    }
