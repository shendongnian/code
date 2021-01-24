    public static IReadOnlyList<IProperty> GetPrimaryKeyProperties<T>(this DbContext dbContext)
    {
        return dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
    }
    public static Expression<Func<T, bool>> FilterByPrimaryKeyPredicate<T>(this DbContext dbContext, object[] id)
    {
        var keyProperties = dbContext.GetPrimaryKeyProperties<T>();
        var parameter = Expression.Parameter(typeof(T), "e");
        var body = keyProperties
            // e => e.PK[i] == id[i]
            .Select((p, i) => Expression.Equal(
                Expression.Property(parameter, p.Name),
                Expression.Convert(
                    Expression.PropertyOrField(Expression.Constant(new { id = id[i] }), "id"),
                    p.ClrType)))
            .Aggregate(Expression.AndAlso);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
    public static IQueryable<TEntity> FilterByPrimaryKey<TEntity>(this DbSet<TEntity> dbSet, DbContext context, object[] id)
        where TEntity : class
    {
        return dbSet.Where(context.FilterByPrimaryKeyPredicate<TEntity>(id));
    }
