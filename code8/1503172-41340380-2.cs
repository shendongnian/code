    public Expression getOrderByQuery<T>(PropertyInfo col)
    {
    	var orderByMethod = typeof(Queryable).GetMethods().Single(
    		method => method.Name == "OrderBy"
    				  && method.IsGenericMethodDefinition
    				  && method.GetGenericArguments().Length == 2
    				  && method.GetParameters().Length == 2);
    
    	var genericOrdebyMethod = 
                            orderByMethod.MakeGenericMethod(typeof(T), col.PropertyType);
    
    	var parameter = Expression.Parameter(typeof(T), "p"); // {p}
    	var property = Expression.Property(parameter, col); // {p.ID}
    	var lambda = Expression.Lambda<Func<T, int>>(property, parameter); // {p => p.ID}
    	
    	var paramList = Expression.Parameter(typeof(IQueryable<T>));
    	
        // {tempList.OrderBy(p => p.ID)}	
    	var orderByMethodExpression = Expression.Call(genericOrdebyMethod, paramList, lambda); 
    
    	return Expression.Lambda(orderByMethodExpression, paramList);
    }
