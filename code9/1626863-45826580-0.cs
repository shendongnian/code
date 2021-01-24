    public static string GetPropertyAttribute<TType>(Expression<Func<TType, object>> property)
    {
    	var memberName = ((MemberExpression)property.Body).Member.Name;
    
    	return string.Join(",",
    		typeof(TType).GetProperties()
    			.Where(p => p.Name == memberName)
    			.Select(p => p.GetCustomAttribute<JsonPropertyAttribute>())
    			.Where(jp => jp != null)
    			.Select(jp => jp.PropertyName)
    	);
    }
