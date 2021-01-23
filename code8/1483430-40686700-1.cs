    public void ConfigureServices(IServiceCollection services)
    {
        // My Db Context is named "ApplicationDbContext", which is the
        // default name. Yours might be something different.
        // Additionally, if you're using a persistence store other than
        // MSSQL Server, you might have a different set of options here.
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        // This sets up the basics of the Identity code. "ApplicationUser"
        // is the name of the model that I use for my basic user. It's simply
        // a POCO that can be modified like any EF model, and it's the default
        // name for a user in the template. "ApplicationRole" is a class that I
        // wrote that inherits from the "IdentityRole" base class. I use it to
        // add a role description, and any other future data I might want to
        // include with my role. I then tell the Identity code to store it's
        // data in the "ApplicationDbContext" that I just setup.
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProvider();
        // This sets up the MVC framework.
        services.AddMvc();
        ...
    }
