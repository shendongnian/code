    public T Get(long id)
    {
        var idName = "ID" + typeof(T).Name; // For Document would be IDDocument
        var parameter = Expression.Parameter(id.GetType());
        var property = Expression.Property(parameter, idName)
        var idValue = Expression.Constant(id, id.GetType());
        var equal = Expression.Equal(property, idValue);
        var predicate = Expression.Lambda<Func<T, bool>>(equal, parameter);
        return entities.SingleOrDefault(predicate);
    }
