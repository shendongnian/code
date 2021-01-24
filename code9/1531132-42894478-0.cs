    public static class OrderByHelper
    {
    	public static IOrderedQueryable<T> ThenBy<T>(this IEnumerable<T> source, string orderBy)
    	{
    		return source.AsQueryable().ThenBy(orderBy);
    	}
    
    	public static IOrderedQueryable<T> ThenBy<T>(this IQueryable<T> source, string orderBy)
    	{
    		return OrderBy(source, orderBy, false);
    	}
    
    	public static IOrderedQueryable<T> OrderBy<T>(this IEnumerable<T> source, string orderBy)
    	{
    		return source.AsQueryable().OrderBy(orderBy);
    	}
    
    	public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy)
    	{
    		return OrderBy(source, orderBy, true);
    	}
    
    	private static IOrderedQueryable<T> OrderBy<T>(IQueryable<T> source, string orderBy, bool initial)
    	{
    		if (string.IsNullOrWhiteSpace(orderBy))
    			orderBy = "ID DESC";
    		var parameter = Expression.Parameter(typeof(T), "x");
    		var expression = source.Expression;
    		foreach (var item in ParseOrderBy(orderBy, initial))
    		{
    			var order = item.PropertyName.Split('.')
    				.Aggregate((Expression)parameter, Expression.PropertyOrField);
    			if (!order.Type.IsValueType || Nullable.GetUnderlyingType(order.Type) != null)
    			{
    				var preOrder = Expression.Condition(
    						Expression.Equal(order, Expression.Constant(null, order.Type)),
    						Expression.Constant(1), Expression.Constant(0));
    				expression = CallOrderBy(expression, Expression.Lambda(preOrder, parameter), item.Direction, initial);
    				initial = false;
    			}
    			expression = CallOrderBy(expression, Expression.Lambda(order, parameter), item.Direction, initial);
    			initial = false;
    		}
    		return (IOrderedQueryable<T>)source.Provider.CreateQuery(expression);
    	}
    
    	private static Expression CallOrderBy(Expression source, LambdaExpression selector, SortDirection direction, bool initial)
    	{
    		return Expression.Call(
    			typeof(Queryable), GetMethodName(direction, initial),
    			new Type[] { selector.Parameters[0].Type, selector.Body.Type },
    			source, Expression.Quote(selector));
    	}
    
    	private static string GetMethodName(SortDirection direction, bool initial)
    	{
    		return direction == SortDirection.Ascending ?
    			(initial ? "OrderBy" : "ThenBy") :
    			(initial ? "OrderByDescending" : "ThenByDescending");
    	}
    
    	private static IEnumerable<OrderByInfo> ParseOrderBy(string orderBy, bool initial)
    	{
    		if (String.IsNullOrEmpty(orderBy))
    			yield break;
    
    		string[] items = orderBy.Split(',');
    
    		foreach (string item in items)
    		{
    			string[] pair = item.Trim().Split(' ');
    
    			if (pair.Length > 2)
    				throw new ArgumentException(String.Format("Invalid OrderBy string '{0}'. Order By Format: Property, Property2 ASC, Property2 DESC", item));
    
    			string prop = pair[0].Trim();
    
    			if (String.IsNullOrEmpty(prop))
    				throw new ArgumentException("Invalid Property. Order By Format: Property, Property2 ASC, Property2 DESC");
    
    			SortDirection dir = SortDirection.Ascending;
    
    			if (pair.Length == 2)
    				dir = ("desc".Equals(pair[1].Trim(), StringComparison.OrdinalIgnoreCase) ? SortDirection.Descending : SortDirection.Ascending);
    
    			yield return new OrderByInfo() { PropertyName = prop, Direction = dir, Initial = initial };
    
    			initial = false;
    		}
    
    	}
    
    	private class OrderByInfo
    	{
    		public string PropertyName { get; set; }
    		public SortDirection Direction { get; set; }
    		public bool Initial { get; set; }
    	}
    
    	private enum SortDirection
    	{
    		Ascending = 0,
    		Descending = 1
    	}
    }
 
