      public static Expression GetObjectExpression(Expression leftExpression)
         {
                MethodInfo miDoAction = typeof(Program).GetMethod("DoAction", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                var callExpr = Expression.Call(miDoAction, leftExpression, Expression.Constant("SearchForThis"), Expression.Constant(ExpressionType.Equal));
    
                return callExpr;
         }	
	 
	
