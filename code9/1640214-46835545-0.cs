    private IHttpContextAccessor _contextAccessor { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    private IServiceProvider _services;
    public ApplicationContext(DbContextOptions<ApplicationContext> options,
        IHttpContextAccessor contextAccessor, IServiceProvider services)
        : base(options)
    {
        _contextAccessor = contextAccessor;
        var user = _contextAccessor.HttpContext.User;
        _services = services;
    }
