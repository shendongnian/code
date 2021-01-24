      public static Expression GetObjectExpression(Expression leftExpression)
         {
                MethodInfo miDoAction = typeof(Program).GetMethod("DoAction", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                var callExpr = Expression.Call(miDoAction, leftExpression, Expression.Constant("SearchForThis"), Expression.Constant(ExpressionType.Equal));
    
                return callExpr;
         }	
	 
	
     Then it is just a matter of a conditional call
	 
	
     Expression leftExpression;
    	 
    	   var isTypeJarray = Expression.TypeIs(leftExpression, typeof(JArray));
    
          return Expression.Condition(isTypeJarray, GetArrayExpression(leftExpression), GetObjectExpression(leftExpression));
    		
