    public static class ExpressionUtils
    {
    	public static Expression<Func<T, TResult>> Expr<T, TResult>(Expression<Func<T, TResult>> e) => e;
    	public static Expression<Func<T1, T2, TResult>> Expr<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> e) => e;
    	public static Expression<Func<T1, T2, T3, TResult>> Expr<T1, T2, T3, TResult>(Expression<Func<T1, T2, T3, TResult>> e) => e;
    	public static Expression<Func<T1, T2, T3, T4, TResult>> Expr<T1, T2, T3, T4, TResult>(Expression<Func<T1, T2, T3, T4, TResult>> e) => e;
    	public static Expression WithParameters(this LambdaExpression expression, params Expression[] values)
    	{
    		return expression.Parameters.Zip(values, (p, v) => new { p, v })
    			.Aggregate(expression.Body, (e, x) => e.ReplaceParameter(x.p, x.v));
    	}
    	public static Expression ReplaceParameter(this Expression expression, ParameterExpression source, Expression target)
    	{
    		return new ParameterReplacer { Source = source, Target = target }.Visit(expression);
    	}
    	class ParameterReplacer : ExpressionVisitor
    	{
    		public ParameterExpression Source;
    		public Expression Target;
    		protected override Expression VisitParameter(ParameterExpression node)
    		{
    			return node == Source ? Target : base.VisitParameter(node);
    		}
    	}
    }
