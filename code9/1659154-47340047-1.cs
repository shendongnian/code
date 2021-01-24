    public static partial class QueryableExtensions
    {
    	public static IQueryable<T> ConvertTimeSpans<T>(this IQueryable<T> source)
    	{
    		var expr = new TimeSpanConverter().Visit(source.Expression);
    		return source == expr ? source : source.Provider.CreateQuery<T>(expr);
    	}
    
    	class TimeSpanConverter : ExpressionVisitor
    	{
    		static readonly Expression<Func<DateTime, int>> ConvertTimeOfDay = dt =>
    			60 * (60 * dt.Hour + dt.Minute) + dt.Second;
    
    		static int ConvertTimespan(TimeSpan ts) => 
    			60 * (60 * ts.Hours + ts.Minutes) + ts.Seconds;
    
    		protected override Expression VisitMember(MemberExpression node)
    		{
    			if (node.Type == typeof(TimeSpan))
    			{
    				if (node.Member.DeclaringType == typeof(DateTime) && node.Member.Name == nameof(DateTime.TimeOfDay))
    					return ConvertTimeOfDay.ReplaceParameter(0, base.Visit(node.Expression));
    				// Evaluate the TimeSpan value, convert and wrap it into closure (to keep non const semantics) 
    				return ConvertTimespan(base.VisitMember(node).Evaluate<TimeSpan>()).ToClosure().Body;
    			}
    			return base.VisitMember(node);
    		}
    
    		protected override Expression VisitBinary(BinaryExpression node)
    		{
    			if (node.Left.Type == typeof(TimeSpan))
    				return Expression.MakeBinary(node.NodeType, Visit(node.Left), Visit(node.Right));
    			return base.VisitBinary(node);
    		}
    	}
    
    	static T Evaluate<T>(this Expression source) => Expression.Lambda<Func<T>>(source).Compile().Invoke();
    
    	static Expression<Func<T>> ToClosure<T>(this T value) => () => value;
    
    	static Expression ReplaceParameter(this LambdaExpression source, int index, Expression target) =>
    		new ParameterReplacer { Source = source.Parameters[index], Target = target }.Visit(source.Body);
    
    	class ParameterReplacer : ExpressionVisitor
    	{
    		public ParameterExpression Source;
    		public Expression Target;
    		protected override Expression VisitParameter(ParameterExpression node) => node == Source ? Target : node;
    	}
    }
