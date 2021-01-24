     public static IEnumerable<object> GetFunctionParameters<TInput, TOutput>(this Expression<Func<TInput, TOutput>> expression)
            {
                var call = expression.Body as MethodCallExpression;
                if (call == null)
                    throw new ArgumentException("Not a method call");
    
                foreach (Expression argument in call.Arguments)
                {
                    LambdaExpression lambda = Expression.Lambda(argument, expression.Parameters);
                    Delegate d = lambda.Compile();
                    yield return d.DynamicInvoke(new object[1]);
                }
            }
