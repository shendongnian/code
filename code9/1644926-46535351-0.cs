    private static readonly Dictionary<Type, object> allSets = new Dictionary<Type, object>.Add(typeof(AppLog), AppLogs);
    
    public CustomSet<TEntity> Set<TEntity>() where TEntity : class
    {
        if (allSets.ContainsKey(TEntity))
        {
            return (CustomSet<TEntity>)allSets[TEntity];
        }
    }
