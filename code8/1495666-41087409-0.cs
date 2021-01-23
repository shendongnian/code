    private readonly Expression<Func<TEntity, TProperty>> _property;
    private Expression<Func<TEntity, bool>> insensitiveEqualityPredicate(string formula)
    {
        return Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(
                Expression.Call(_property.Body, "ToLower", Type.EmptyTypes),
                Expression.Constant(formula.ToLower(), typeof(string))
            ),
            _property.Parameters
        );
    }
