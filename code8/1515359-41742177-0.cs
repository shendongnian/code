    public Expression<Func<T, bool>> getExpression<T>(string columnName)
    {
    	var param = Expression.Parameter(typeof(T));
    	var equal = Expression.Equal(Expression.Property(param, columnName), Expression.Constant(true));
    	return (Expression<Func<T, bool>>)Expression.Lambda(equal, param);
    }
