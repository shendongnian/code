    public string ResolveConnectionId(string connectionId)
    {            
        while (!IsEligibleConnectionId(connectionId) && !string.IsNullOrEmpty(connectionId))
            connectionId = MemoryCache.Default.Get(connectionId) as string;
           
        return connectionId;
    }
