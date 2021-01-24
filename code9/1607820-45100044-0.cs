    ParameterExpression parameter = Expression.Parameter(classType, "a");
    
    //a.Id GUID
    MemberExpression property = Expression.Property(parameter, "Id");
    //a.ID as object
    var newProp = Expression.TypeAs(property, typeof(object));
    var delegateType = typeof(Func<,>).MakeGenericType(classType, typeof(object));
    var yourExpression = Expression.Lambda(delegateType, newProp, parameter);
    
    MethodInfo methodInfo = typeof(PersistenceService).GetMethods()
    .Where(x => x.Name == "Get")
    .Select(x => new { M = x, P = x.GetParameters() })
    .Where(x => x.P.Length == 2
    			&& x.P[0].ParameterType.IsGenericType
    			&& x.P[0].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>)                             
    			&& x.P[1].ParameterType == typeof(object))
    .Select(x => new { x.M, A = x.P[0].ParameterType.GetGenericArguments() })
    .Where(x => x.A[0].IsGenericType
    			&& x.A[0].GetGenericTypeDefinition() == typeof(Func<,>))
    .Select(x => new { x.M, A = x.A[0].GetGenericArguments() })
    .Where(x => x.A[0].IsGenericParameter
    			&& x.A[1] == typeof(object))
    .Select(x => x.M)
    .SingleOrDefault();
    
    if(methodInfo != null)
    {
    	MethodInfo method = methodInfo.MakeGenericMethod(classType);
    	dynamic dEnumeration = method.Invoke(PersistenceService, new object[] { yourExpression, pg.GUID });
    	dynamic dEntity = Enumerable.FirstOrDefault(dEnumeration);
    	...
	
