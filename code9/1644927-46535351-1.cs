    private static readonly Dictionary<Type, object> allSets = new Dictionary<Type, object>.Add(typeof(AppLog), AppLogs);
    
    public CustomSet<TEntity> Set<TEntity>() where TEntity : class
    {
        Type key = typeof (TEntity);       
 
        if (allSets.ContainsKey(key))
        {
            return (CustomSet<TEntity>)allSets[key];
        }
    }
