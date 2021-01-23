    public static class WcfQueryableExtensions
    {
    	public static IQueryable<T> WhereEqual<T>(this IQueryable<T> source, Expression<Func<T, DateTime>> selector, DateTime date)
    	{
    		var dateValue = ExpressionUtils.Expr(() => date).Body;
    		var predicate = Expression.Lambda<Func<T, bool>>(
    			ExpressionUtils.Expr((DateTime x, DateTime y) =>
    				x.Year == y.Year && x.Month == y.Month && x.Day == y.Day)
    				.WithParameters(selector.Body, dateValue),
    			selector.Parameters);
    		return source.Where(predicate);
    	}
    }
