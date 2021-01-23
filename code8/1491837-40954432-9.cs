    public static class QueryableExtensions
    {
    	public static IQueryable<T> ReduceCasts<T>(this IQueryable<T> source)
    	{
    		var expression = new CastReducer().Visit(source.Expression);
    		if (source.Expression == expression) return source;
    		return source.Provider.CreateQuery<T>(expression);
    	}
    
    	class CastReducer : ExpressionVisitor
    	{
    		protected override Expression VisitUnary(UnaryExpression node)
    		{
    			if (node.NodeType == ExpressionType.Convert &&
    				node.Type.IsAssignableFrom(node.Operand.Type))
    			{
    				// Strip the Convert
    				return Visit(node.Operand);
    			}
    			return base.VisitUnary(node);
    		}
    	}
    }
