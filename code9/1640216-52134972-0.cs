    private IHttpContextAccessor _contextAccessor { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    private Lazy<UserManager<ApplicationUser>> _userManager;
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options,
        IHttpContextAccessor contextAccessor, IServiceProvider services)
        : base(options)
    {
        _contextAccessor = contextAccessor;
        var user = _contextAccessor.HttpContext.User;
        _userManager = new Lazy<UserManager<ApplicationUser>>(() =>
                    services.GetRequiredService<UserManager<ApplicationUser>>());
    }
