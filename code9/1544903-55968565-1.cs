    // Startup.cs:
    
    services.AddMemoryCache();
    services.AddSingleton<CacheService>();
    
    // CacheService.cs:
    
    public IMemoryCache Cache { get; }
    
    public CacheService(IMemoryCache cache)
    {
      Cache = cache;
    }
    
    // RoleService:
    
    private CacheService cacheService;
    public RoleService(CacheService cacheService)
    {
        this.cacheService = cacheService;
    }
