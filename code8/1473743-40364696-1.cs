    var innerParameter = Expression.Parameter(typeof(SecondClass), "y");
    var innerPredicate = Expression.Lambda<Func<SecondClass, bool>>(
    	Expression.AndAlso(
    		Expression.Equal(Expression.Property(innerParameter, "ReferenceId"), Expression.Constant(id)),
    		Expression.MakeBinary(ExpressionTypeDictionary[operatorType], Expression.Property(innerParameter, "Value"), Expression.Constant(value))),
    	innerParameter);
    var parameter = Expression.Parameter(typeof(FirstClass), "x");
    var predicate = Expression.Lambda<Func<FirstClass, bool>>(
    	Expression.Call(
    		typeof(Enumerable), "Any", new Type[] { typeof(SecondClass) },
    		Expression.Property(parameter, "MyList"), innerPredicate),
    	parameter);
