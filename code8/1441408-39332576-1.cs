     private Expression CreateExpression(Type interfaceType, Type methodReturnType, MethodInfo methodName)
            {
                ParameterExpression parameter = Expression.Parameter(interfaceType, "srv");
                Expression callExpression = Expression.Call(parameter, methodName.Name,null, null);
    
                Type expressionType = typeof(Expression<>);
                Type lambdaType = typeof(LambdaExpression);
                Type funcType = typeof(Func<,>).MakeGenericType(interfaceType, methodReturnType);
                Type expressionGenericType = expressionType.MakeGenericType(funcType);
    
                string methodSignature = "System.Linq.Expressions.LambdaExpression Lambda(System.Linq.Expressions.Expression, System.Linq.Expressions.ParameterExpression[])";
                var lambdaMethod = typeof(Expression).GetMethods()
                    .Single(mi => mi.ToString() == methodSignature);
    
                Expression lambdaExpression = (Expression)lambdaMethod.Invoke(this, new object[] { callExpression, new ParameterExpression[] { parameter } });
                return lambdaExpression;
            }
