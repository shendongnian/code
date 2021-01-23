    public static class EFExtensions
    {
    	public static string ToCustomDateFormat(this DateTime value)
    	{
    		// Should never happen
    		throw new InvalidOperationException();
    	}
    
    	public static IQueryable<T> ApplyCustomDateFormat<T>(this IQueryable<T> source)
    	{
    		var expression = new CustomDateFormatBinder().Visit(source.Expression);
    		if (source.Expression == expression) return source;
    		return source.Provider.CreateQuery<T>(expression);
    	}
    
    	class CustomDateFormatBinder : ExpressionVisitor
    	{
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			if (node.Method.DeclaringType == typeof(EFExtensions) && node.Method.Name == "ToCustomDateFormat")
    			{
    				var date = Visit(node.Arguments[0]);
    				var year = DatePart(date, v => DbFunctions.Right("0000" + v.Year, 4));
    				var month = DatePart(date, v => v.Month.ToString());
    				var day = DatePart(date, v => v.Day.ToString());
    				var hour = DatePart(date, v => (1 + (v.Hour + 11) % 12).ToString());
    				var minute = DatePart(date, v => DbFunctions.Right("0" + v.Minute, 2));
    				var second = DatePart(date, v => DbFunctions.Right("0" + v.Second, 2));
    				var amPM = DatePart(date, v => v.Hour < 12 ? "AM" : "PM");
    				var dateSeparator = Expression.Constant("/");
    				var timeSeparator = Expression.Constant(":");
    				var space = Expression.Constant(" ");
    				var result = Expression.Call(
    					typeof(string).GetMethod("Concat", new Type[] { typeof(string[]) }),
    					Expression.NewArrayInit(typeof(string),
    						month, dateSeparator, day, dateSeparator, year, space,
    						hour, timeSeparator, minute, timeSeparator, second, space, amPM));
    				return result;    
    			}
    			return base.VisitMethodCall(node);
    		}
    
    		Expression DatePart(Expression date, Expression<Func<DateTime, string>> part)
    		{
    			var parameter = part.Parameters[0];
    			parameterMap.Add(parameter, date);
    			var body = Visit(part.Body);
    			parameterMap.Remove(parameter);
    			return body;
    		}
    
    		Dictionary<ParameterExpression, Expression> parameterMap = new Dictionary<ParameterExpression, Expression>();
    
    		protected override Expression VisitParameter(ParameterExpression node)
    		{
    			Expression replacement;
    			return parameterMap.TryGetValue(node, out replacement) ? replacement : node;
    		}
    	}
    }
