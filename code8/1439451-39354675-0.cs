    public static partial class QueryableExtensions()
    {
    	public static IQueryable SelectProperty(this IQueryable source, string path)
    	{
    		var parameter = Expression.Parameter(source.ElementType, "x");
    		var property = path.Split(',')
    			.Aggregate((Expression)parameter, Expression.PropertyOrField);
    		var selector = Expression.Lambda(property, parameter);
    		var selectCall = Expression.Call(
    			typeof(Queryable), "Select", new[] { parameter.Type, property.Type },
    			source.Expression, Expression.Quote(selector));
    		return source.Provider.CreateQuery(selectCall);
    	}
    }
