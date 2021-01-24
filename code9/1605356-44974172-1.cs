    public static IQueryable<T> WhereLike<T>(this IQueryable<T> source, string propertyName, 
        string pattern)
    {
    	if (source == null) throw new ArgumentNullException("source");
    	if (propertyName == null) throw new ArgumentNullException("propertyName");
    
    	var a = Expression.Parameter(typeof(T), "a");
    	var prop = Expression.PropertyOrField(a, propertyName);
    
    	var expr = Expression.Call(
    			typeof(SqlMethods), "Like",
    			null,
    			prop, Expression.Constant(pattern));
     	
        var lambda = Expression.Lambda<Func<T, bool>>(expr, a); 
    	return source.Where(lambda);
    }
