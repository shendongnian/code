    public virtual void Update<T>(List<Expression<Func<T, object>>> excludeColumns, params T[] items)
    {
        foreach (T item in items)
        {
            _entities.Entry(item).State = EntityState.Modified;
            foreach (var predicate in excludeColumns)            
                _entities.Entry(item).Property(predicate).IsModified = false;
        }
        _entities.SaveChanges();
    }
