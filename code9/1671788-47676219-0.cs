    .ForEach(entityType =>
    {
        builder.Entity(entityType.ClrType).Property<Boolean>("IsDeleted");
        var parameter = Expression.Parameter(entityType.ClrType, "e");
        var body = Expression.Equal(
            Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(bool) }, parameter, Expression.Constant("IsDeleted")),
        Expression.Constant(false));
        builder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
    });
