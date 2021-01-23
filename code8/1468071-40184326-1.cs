    public static Func<MyObject, bool> AutoCompleteExpression()
    {
	   ParameterExpression parameterType = Expression.Parameter(typeof(MyObject), "object");
	   MemberExpression typeColumnProp1 = Expression.Property(parameterType, "PROP1");
	   MemberExpression typeColumnProp2 = Expression.Property(parameterType, "PROP2");
	
	   MethodInfo containsMethodInfo = typeof(StringExtensions).GetMethod("Contains",new[] { typeof(string), typeof(string) },null);	
	   ConstantExpression constant1 = Expression.Constant(param1, typeof(string));
	   ConstantExpression constant2 = Expression.Constant(param2, typeof(string));
	
	   MethodCallExpression expression1 = Expression.Call(null, containsMethodInfo, typeColumnProp1, constant1);
	   MethodCallExpression expression2 = Expression.Call(null, containsMethodInfo, typeColumnProp2, constant2);
	
	   BinaryExpression resultExpression = Expression.And(expression1,expression2);
	
	   return Expression.Lambda<Func<MyObject, bool>>(resultExpression, parameterType).Compile();
     }
