    public static class QueryableExtensions
    {
    	public static IQueryable GroupByMember(this IQueryable source, string memberPath)
    	{
    		var parameter = Expression.Parameter(source.ElementType, "x");
    		var member = memberPath.Split('.')
    			.Aggregate((Expression)parameter, Expression.PropertyOrField);
    		var selector = Expression.Lambda(member, parameter);
    		var groupByCall = Expression.Call(typeof(Queryable), "GroupBy",
    			new Type[] { parameter.Type, member.Type },
    			source.Expression, Expression.Quote(selector));
    		return source.Provider.CreateQuery(groupByCall);
    	}
    }
