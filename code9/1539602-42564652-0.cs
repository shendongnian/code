    public static Func<MainList, T> CreateSelect<T>(string fields)
    {
    	var parameter = Expression.Parameter(typeof(MainList), "n");
    	var bindings = fields.Split(',')
    		.Select(name => name.Trim())
    		.Select(name => Expression.Bind(
    			typeof(T).GetProperty(name),
    			Expression.Property(parameter, name)
    		));
    	var newT = Expression.MemberInit(Expression.New(typeof(T)), bindings);
    	var lambda = Expression.Lambda<Func<MainList, T>>(newT, parameter);
    	return lambda.Compile();
    }
