    public static Func<MyObject, bool> AutoCompleteExpression()
    {
       // Create ParameterExpression
	   ParameterExpression parameterType = Expression.Parameter(typeof(MyObject), "object");
       
       // Create MemberExpression for Columns
	   MemberExpression typeColumnProp1 = Expression.Property(parameterType, "PROP1");
	   MemberExpression typeColumnProp2 = Expression.Property(parameterType, "PROP2");
	   
       // Create MethoIndo
	   MethodInfo containsMethodInfo = typeof(StringExtensions).GetMethod("Contains",new[] { typeof(string), typeof(string) },null);	
       
       // Create ConstantExpression values
	   ConstantExpression constant1 = Expression.Constant(param1, typeof(string));
	   ConstantExpression constant2 = Expression.Constant(param2, typeof(string));
	
       // Expression for calling methods
	   MethodCallExpression expression1 = Expression.Call(null, containsMethodInfo, typeColumnProp1, constant1);
	   MethodCallExpression expression2 = Expression.Call(null, containsMethodInfo, typeColumnProp2, constant2);
	
       // Combine `MethodCallExpression` to create Binary Expression
	   BinaryExpression resultExpression = Expression.And(expression1,expression2);
	
        // Compile Expression tree to fetch `Func<MyObject, bool>`
	   return Expression.Lambda<Func<MyObject, bool>>(resultExpression, parameterType).Compile();
     }
