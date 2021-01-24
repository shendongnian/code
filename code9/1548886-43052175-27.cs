    public static IIncludable<TEntity, TProperty> Include<TEntity, TProperty>(
        this IIncludable<TEntity> includes,
        Expression<Func<TEntity, TProperty>> propertySelector)
        where TEntity : class
    {
        var result = ((Includable<TEntity>)includes).Input.Include(propertySelector);
        return new Includable<TEntity, TProperty>(result);
    }
    public static IIncludable<TEntity, TOtherProperty>
        ThenInclude<TEntity, TOtherProperty, TProperty>(
            this IIncludable<TEntity, TProperty> includes,
            Expression<Func<TProperty, TOtherProperty>> propertySelector)
        where TEntity : class
    {
        var result = ((Includable<TEntity, TProperty>)includes)
            .IncludableInput.ThenInclude(propertySelector);
        return new Includable<TEntity, TOtherProperty>(result);
    }
    public static IIncludable<TEntity, TOtherProperty>
        ThenInclude<TEntity, TOtherProperty, TProperty>(
            this IIncludable<TEntity, IEnumerable<TProperty>> includes,
            Expression<Func<TProperty, TOtherProperty>> propertySelector)
        where TEntity : class
    {
        var result = ((Includable<TEntity, IEnumerable<TProperty>>)includes)
            .IncludableInput.ThenInclude(propertySelector);
        return new Includable<TEntity, TOtherProperty>(result);
    }
