    .ForEach(entityType =>
    {
        builder.Entity(entityType.ClrType).Property<Boolean>("IsDeleted");
        var parameter = Expression.Parameter(entityType.ClrType, "e");
        var body = filter.Body.ReplaceParameter(filter.Parameters[0], parameter);
        builder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
    });
