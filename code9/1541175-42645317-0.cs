    public class MyLazyLoadingObjectMapper : IObjectMapper
    {
    	public bool IsMatch(TypePair context)
    	{
    		return context.SourceType.IsGenericType && context.SourceType.GetGenericTypeDefinition() == typeof(MyLazyLoadingObject<>);
    	}
    
    	public Expression MapExpression(TypeMapRegistry typeMapRegistry, IConfigurationProvider configurationProvider, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
    	{
    		var item = Expression.Property(sourceExpression, "Item");
    		Expression result = item;
    		if (item.Type != destExpression.Type)
    		{
    			var typeMap = configurationProvider.ResolveTypeMap(item.Type, destExpression.Type);
    			result = Expression.Invoke(typeMap.MapExpression, item, destExpression, contextExpression);
    		}
    		// source != null && source.HasData ? result : default(TDestination)
    		return Expression.Condition(
    			Expression.AndAlso(
    				Expression.NotEqual(sourceExpression, Expression.Constant(null)),
    				Expression.Property(sourceExpression, "HasData")
    			),
    			result,
    			Expression.Default(destExpression.Type)
    		);
    	}
    }
