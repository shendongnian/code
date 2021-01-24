    repository.IncludeQuery(query, a => a.First.Second.Select(b => b.Third), a => a.Fourth);
    private IQueryable<TCall> IncludeQuery<TCall>(
    	params Expression<Func<TCall, object>>[] includeProperties) where TCall : class
    {
	    IQueryable<TCall> query;
        query = context.Set<TCall>();
    	foreach (var property in includeProperties)
    	{
    		if (!(property.Body is MethodCallExpression))
    			query = query.Include(property);
    		else
    		{
    			var expression = property.Body as MethodCallExpression;
    
    			var include = GenerateInclude(expression);
    
    			query = query.Include(include);
    		}
    	} 
    
    	return query;
    }
    
    private string GenerateInclude(MethodCallExpression expression)
    {
    	var result = default(string);
    
    	foreach (var argument in expression.Arguments)
    	{
    		if (argument is MethodCallExpression)
    			result += GenerateInclude(argument as MethodCallExpression) + ".";
    		else if (argument is MemberExpression)
    			result += ((MemberExpression)argument).Member.Name + ".";
    		else if (argument is LambdaExpression)
    			result += ((MemberExpression)(argument as LambdaExpression).Body).Member.Name + ".";
    	}
    
    	return result.TrimEnd('.');
    } 
