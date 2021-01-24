    public void Update<T>(T entity, Dictionary<string, string> valuesToUpdate) where T : class
    {
        var entry = ChangeTracker.Entries<T>().Where(e => object.ReferenceEquals(e.Entity, entity)).Single();
        foreach (var name in valuesToUpdate.Keys)
        {
            var pi = typeof(T).GetProperty(name);
            pi.SetValue(entity, Convert.ChangeType(valuesToUpdate[pi.Name], pi.PropertyType));
            entry.Property(pi.Name).IsModified = true;
        }
    }
