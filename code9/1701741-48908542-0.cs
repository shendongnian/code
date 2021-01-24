    public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> source, string propertyName)
    {
    	if (source == null)
    	{
    		throw new ArgumentNullException("source");
    	}
    	else
    	{
    
    		if (propertyName.EndsWith(" ASC", StringComparison.OrdinalIgnoreCase))
    			propertyName = propertyName.Replace(" ASC", "");
    
    		// DataSource control passes the sort parameter with a direction
    		// if the direction is descending           
    		int descIndex = propertyName.IndexOf(" DESC", StringComparison.OrdinalIgnoreCase);
    		if (descIndex >= 0)
    		{
    			propertyName = propertyName.Substring(0, descIndex).Trim();
    		}
    
    		ParameterExpression parameter = Expression.Parameter(source.ElementType, String.Empty);
    		MemberExpression property = Expression.Property(parameter, propertyName);
    		LambdaExpression lambda = Expression.Lambda(property, parameter);
    
    		string methodName = (descIndex < 0) ? "OrderBy" : "OrderByDescending";
    
    		Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
    																				new Type[] { source.ElementType, property.Type },
    																				source.Expression, Expression.Quote(lambda));
    
    		return source.Provider.CreateQuery<T>(methodCallExpression) as IOrderedQueryable<T>;
    	}
    }
