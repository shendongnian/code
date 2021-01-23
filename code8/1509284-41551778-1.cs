    public static async Task<IEnumerable<TParent>> QueryParentChildAsync<TParent, 
                                                                         TChild, 
                                                                         TParentKey>(
        this IDbConnection connection,
        string sql,
        Func<TParent, TParentKey> parentKeySelector,
        Func<TParent, IList<TChild>> childSelector,
        dynamic param = null, 
        IDbTransaction transaction = null, 
        bool buffered = true, 
        string splitOn = "Id", 
        int? commandTimeout = null, 
        CommandType? commandType = null)
    {
        var cache = new Dictionary<TParentKey, TParent>();
    
        await connection.QueryAsync<TParent, TChild, TParent>(
            sql,
            (parent, child) =>
                {
                    var key = parentKeySelector(parent);
                    if (!cache.ContainsKey(key ))
                    {
                        cache.Add(key, parent);
                    }    
                    var cachedParent = cache[key];
                    var children = childSelector(cachedParent);
                    children.Add(child);
                    return cachedParent;
                },
            param as object, 
            transaction, 
            buffered, 
            splitOn, 
            commandTimeout, 
            commandType);
    
        return cache.Values;
    }
