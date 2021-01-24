    public static partial class ExpressionUtils
    {
    	public static Expression ReplaceParameter(this Expression expr, ParameterExpression source, Expression target) =>
    		new ParameterReplacer { Source = source, Target = target }.Visit(expr);
    
    	class ParameterReplacer : System.Linq.Expressions.ExpressionVisitor
    	{
    		public ParameterExpression Source;
    		public Expression Target;
    		protected override Expression VisitParameter(ParameterExpression node) => node == Source ? Target : node;
    	}
    }
