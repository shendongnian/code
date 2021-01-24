      public static Expression GetArrayExpression(Expression leftExpression)
       {
    	Type predType = typeof(Func<,>).MakeGenericType(typeof(JToken), typeof(bool));
    
    	MethodInfo anyMethod = (MethodInfo)GetGenericMethod(typeof(Enumerable), "Any", new[] { typeof(JToken) }, new[] { typeof(JArray), predType }, BindingFlags.Static);
    
    	MethodInfo miDoAction = typeof(Program).GetMethod("DoAction", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
    
    	ParameterExpression p = Expression.Parameter(typeof(JToken), "item");
    
    	var callExpr1 = Expression.Lambda<Func<JToken, bool>>(Expression.Call(miDoAction, p, Expression.Constant("SearchForThis"), Expression.Constant(ExpressionType.Equal)), p);
    	var callExpr = Expression.Call(anyMethod, leftExpression, callExpr1);
    
    	return callExpr;
    
       }
   
