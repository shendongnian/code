    public static IQyertable<YourEntity> OnlyActiveEntities(this YourDbContext context, Action<DbSet<YourEntity>> setConfigurator = null)
    {
        var dbSet = context.Set<YourEntity>();
        setConfigurator?.Invoke(dbSet); 
        
        return context.Set<YourEntity>().AsQueriable().Where(entity => entity.Active == true);
    }
