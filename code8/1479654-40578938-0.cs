    	private IQueryable<T> AddOrderBy<T>(IQueryable<T> query, Expression<Func<T, object>> orderByProperty, bool isAscending, bool isFirst)
    {
		Expression<Func<IOrderedQueryable<int>, IQueryable<int>>> methodDef = isAscending 
			? (isFirst ? (Expression<Func<IOrderedQueryable<int>, IQueryable<int>>>)(q => q.OrderBy(x => x)) : (Expression<Func<IOrderedQueryable<int>, IQueryable<int>>>)(q => q.ThenBy(x => x)))
			: (isFirst ? (Expression<Func<IOrderedQueryable<int>, IQueryable<int>>>)(q => q.OrderByDescending(x => x)) : (Expression<Func<IOrderedQueryable<int>, IQueryable<int>>>)(q => q.ThenByDescending(x => x)));
		
		// get the property type
		var propExpression = orderByProperty.Body.NodeType == ExpressionType.Convert && orderByProperty.Body.Type == typeof(object)
			? (LambdaExpression)Expression.Lambda(((UnaryExpression)orderByProperty.Body).Operand, orderByProperty.Parameters)
			: orderByProperty;
		
		var methodInfo = ((MethodCallExpression)methodDef.Body).Method.GetGenericMethodDefinition().MakeGenericMethod(typeof(T), propExpression.Body.Type);
		return (IQueryable<T>)methodInfo.Invoke(null, new object[]{query, propExpression});
	}
    
