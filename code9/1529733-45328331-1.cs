    public void RemapConnectionId(string newConnectionId, string oldConnectionId)
    {
        if(newConnectionId != null && newConnectionId != oldConnectionId)
            MemoryCache.Default.Set(oldConnectionId, newConnectionId, ...);
    }
