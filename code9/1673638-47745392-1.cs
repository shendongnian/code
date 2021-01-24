    public static class ExpressionExtensions
    {
    	public static TT Inline<T, TT>(this Expression<Func<T, TT>> expression, T item)
    	{
    		// This will only execute while run in memory.
    		// LINQ to Entities / EntityFramework will never invoke this
    		return expression.Compile()(item);
    	}
    
    	public static IQueryable<T> ApplyInlines<T>(this IQueryable<T> expression)
    	{
    		var finalExpression = expression.Expression.ApplyInlines().InlineInvokes();
    		var transformedQuery = expression.Provider.CreateQuery<T>(finalExpression);
    		return transformedQuery;
    	}
    
    	public static Expression ApplyInlines(this Expression expression) {
    		return new ExpressionInliner().Visit(expression);
    	}
    
    	private class ExpressionInliner : ExpressionVisitor
    	{
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			if (node.Method.Name == "Inline" && node.Method.DeclaringType == typeof(ExpressionExtensions))
    			{
    				var expressionValue = (Expression)Expression.Lambda(node.Arguments[0]).Compile().DynamicInvoke();
    				var arg = node.Arguments[1];
    				var res = Expression.Invoke(expressionValue, arg);
    				return res;
    			}
    			return base.VisitMethodCall(node);
    		}
    	}
    }
    
    // https://codereview.stackexchange.com/questions/116530/in-lining-invocationexpressions/147357#147357
    public static class ExpressionHelpers
    {
    	public static TExpressionType InlineInvokes<TExpressionType>(this TExpressionType expression)
    		where TExpressionType : Expression
    	{
    		return (TExpressionType)new InvokeInliner().Inline(expression);
    	}
    
    	public static Expression InlineInvokes(this InvocationExpression expression)
    	{
    		return new InvokeInliner().Inline(expression);
    	}
    
    	public class InvokeInliner : ExpressionVisitor
    	{
    		private Stack<Dictionary<ParameterExpression, Expression>> _context = new Stack<Dictionary<ParameterExpression, Expression>>();
    		public Expression Inline(Expression expression)
    		{
    			return Visit(expression);
    		}
    
    		protected override Expression VisitInvocation(InvocationExpression e)
    		{
    		    var callingLambda = e.Expression as LambdaExpression;
    		    if (callingLambda == null)
    		        return base.VisitInvocation(e);
    		    var currentMapping = new Dictionary<ParameterExpression, Expression>();
    		    for (var i = 0; i < e.Arguments.Count; i++)
    		    {
    		        var argument = Visit(e.Arguments[i]);
    		        var parameter = callingLambda.Parameters[i];
    		        if (parameter != argument)
    		            currentMapping.Add(parameter, argument);
    		    }
    		    if (_context.Count > 0)
    		    {
    				var existingContext = _context.Peek();
    				foreach (var kvp in existingContext)
    				{
    					if (!currentMapping.ContainsKey(kvp.Key))
    						currentMapping[kvp.Key] = kvp.Value;
    				}
    			}
    
    			_context.Push(currentMapping);
    			var result = Visit(callingLambda.Body);
    			_context.Pop();
    			return result;
    		}
    
    		protected override Expression VisitParameter(ParameterExpression e)
    		{
    			if (_context.Count > 0)
    			{
    				var currentMapping = _context.Peek();
    				if (currentMapping.ContainsKey(e))
    					return currentMapping[e];
    			}
    			return e;
    		}
    	}
    }
