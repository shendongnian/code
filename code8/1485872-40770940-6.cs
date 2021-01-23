    public static class WcfQueryableExtensions
    {
    	public static IQueryable<T> AsWcfQueryable<T>(this IQueryable<T> source)
    	{
    		var expression = new WcfConverter().Visit(source.Expression);
    		if (expression == source.Expression) return source;
    		return source.Provider.CreateQuery<T>(expression);
    	}
    
    	class WcfConverter : ExpressionVisitor
    	{
    		protected override Expression VisitBinary(BinaryExpression node)
    		{
    			if (node.NodeType == ExpressionType.Equal && node.Left.Type == typeof(DateTime))
    				return ExpressionUtils.Expr((DateTime x, DateTime y) =>
    					x.Year == y.Year && x.Month == y.Month && x.Day == y.Day)
    					.WithParameters(Visit(node.Left), Visit(node.Right));
    			return base.VisitBinary(node);
    		}
    	}
    }
