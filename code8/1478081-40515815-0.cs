    public static class DynamicPLINQ
    {
    	public static OrderedParallelQuery<T> OrderBy<T>(this ParallelQuery<T> source, string ordering, params object[] values)
    	{
    		var query = Enumerable.Empty<T>().AsQueryable();
    		var orderedQuery = query.OrderBy(ordering, values);
    		var binder = new ParallelQueryBinder();
    		binder.source = query;
    		binder.target = source;
    		var queryExpr = binder.Visit(orderedQuery.Expression);
    		return (OrderedParallelQuery<T>)query.Provider.Execute(queryExpr);
    	}
    
    	class ParallelQueryBinder : ExpressionVisitor
    	{
    		public object source;
    		public object target;
    		protected override Expression VisitConstant(ConstantExpression node)
    		{
    			if (node.Value == source)
    				return Expression.Constant(target);
    			return base.VisitConstant(node);
    		}
    		protected override Expression VisitUnary(UnaryExpression node)
    		{
    			if (node.NodeType == ExpressionType.Quote)
    				return Visit(node.Operand);
    			return base.VisitUnary(node);
    		}
    		static readonly string[] Methods = { "OrderBy", "OrderByDescending", "ThenBy", "ThenByDescending" };
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			if (node.Method.IsStatic && node.Method.DeclaringType == typeof(Queryable) && Methods.Contains(node.Method.Name))
    			{
    				var arguments = node.Arguments.Select(Visit).ToArray();
    				var result = Expression.Call(typeof(ParallelEnumerable), node.Method.Name, node.Method.GetGenericArguments(), arguments);
    				return result;
    			}
    			return base.VisitMethodCall(node);
    		}
    	}
    }
