    public void Detach<T>(T entity)
        where T : class
    {
        Entry( entity ).State = EntityState.Detached;
        foreach(var prop in Entry( entity ).Properties) {
            if (prop.Metadata.IsKey()) {
                prop.CurrentValue = 0;
            }
        }
    }
