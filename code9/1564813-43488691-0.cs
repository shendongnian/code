    public static class QueryableExtensions
    {
    	public static IQueryable<T> BindDbFunctions<T>(this IQueryable<T> source)
    	{
    		var expression = new DbFunctionsBinder().Visit(source.Expression);
    		if (expression == source.Expression) return source;
    		return source.Provider.CreateQuery<T>(expression);
    	}
    	public static IQueryable BindDbFunctions(this IQueryable source)
    	{
    		var expression = new DbFunctionsBinder().Visit(source.Expression);
    		if (expression == source.Expression) return source;
    		return source.Provider.CreateQuery(expression);
    	}
    
    	class DbFunctionsBinder : ExpressionVisitor
    	{
    		protected override Expression VisitMember(MemberExpression node)
    		{
    			if (node.Expression != null && node.Expression.Type == typeof(DateTime) && node.Member.Name == "Date")
    			{
    				var dateValue = Expression.Convert(Visit(node.Expression), typeof(DateTime?));
    				var methodCall = Expression.Call(typeof(DbFunctions), "TruncateTime", Type.EmptyTypes, dateValue);
    				return Expression.Convert(methodCall, typeof(DateTime));
    			}
    			return base.VisitMember(node);
    		}
    	}
    }
