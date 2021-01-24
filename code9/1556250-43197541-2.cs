    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
    {
        ApplicationUserManager manager = new ApplicationUserManager(new UserStore<User>(context.Get<ApplicationDbContext>()));
        ...
    }
