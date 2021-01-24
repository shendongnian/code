    public static partial class QueryableExtensions
    {
    	public static IQueryable<T> WhereEquals<T>(this IQueryable<T> source, string memberPath, string value)
    	{
    		var parameter = Expression.Parameter(typeof(T), "e");
    		var left = memberPath.Split('.').Aggregate((Expression)parameter, Expression.PropertyOrField);
    		var right = Expression.Constant(ToType(value, left.Type), left.Type);
    		var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(left, right),	parameter);
    		return source.Where(predicate);
    	}
    
    	private static object ToType(string value, Type type)
    	{
    		if (type == typeof(string)) return value;
    		if (string.IsNullOrEmpty(value)) return null;
    		return Convert.ChangeType(value, Nullable.GetUnderlyingType(type) ?? type);
    	}
    }
