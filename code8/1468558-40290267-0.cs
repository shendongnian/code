    public virtual T Add(T entity, out CustomMessage customMessage)
    {
        var entry = _dbset.Add<T>(entity);
        ...
        return entry.Entity;
    }
