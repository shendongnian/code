    public static class AMExtensions
    {
    	public static void From<TSource, TDestination, TMember>(this IMemberConfigurationExpression<TSource, TDestination, TMember> opt, string name)
    	{
    		var parameter = Expression.Parameter(typeof(TSource), "src");
    		var body = Expression.PropertyOrField(parameter, name);
    		var selector = Expression.Lambda(body, parameter);
    		opt.MapFrom((dynamic)selector);
    	}
    }
