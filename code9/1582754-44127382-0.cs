    private readonly IServiceScopeFactory _scopeFactory;
    
    public RoleService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    
    public async Task<ApiResource[]> GetApiResourcesByIds(int[] ids)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
        }
    }
