    public static IQueryable<T> WithoutId<T>(
        this IQueryable<T> entities,
        Expression<Func<T, int>> propertySelector,
        ICollection<int> ids) {
        var property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;
        ParameterExpression parameter = Expression.Parameter(typeof(T));
        var expression = Expression.Lambda<Func<T, bool>>(
            Expression.Not(
                Expression.Call(
                    Expression.Constant(ids),
                    typeof(ICollection<int>).GetMethod("Contains"), 
                    Expression.Property(parameter, property))), 
            parameter);
        if (!ids.Any()) {                                          // here is the trick
            expression = Expression.Lambda<Func<TEntity, bool>>(
                Expression.Constant(false), 
                parameter);
        }
        return entities.Where(expression);
    }
