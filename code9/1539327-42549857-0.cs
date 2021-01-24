    public void Detach<T>(T entity)
        where T : class
    {
        Entry( entity ).State = EntityState.Detached;
    }
