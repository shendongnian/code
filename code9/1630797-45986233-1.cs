            // Create parameter that will be passed to catch block 
            var excepParam = Expression.Parameter(typeof(InvalidCastException));
            MethodInfo handleExceptionMethodInfo = simpleMath.GetType().GetMethods().Where(x => x.Name == "HandleException").ToArray()[0];
            MethodCallExpression returnMethodWithParameters2 = Expression.Call(Expression.Constant(simpleMath), handleExceptionMethodInfo, excepParam);
            UnaryExpression returnMethodWithParametersAsObject2 = Expression.Convert(returnMethodWithParameters2, typeof(object));
            // Put created parameter before to CatchBlock.Variable using Expression.Catch 
            // that takes the first argument as ParameterExpression
            TryExpression tryCatchMethod2 = TryExpression.TryCatch(returnMethodWithParametersAsObject, Expression.Catch(excepParam, returnMethodWithParametersAsObject2));
            var exppp = Expression.Lambda<Func<object, object, object>>(tryCatchMethod2, parameters);
            Func<object, object, object> func2 = Expression.Lambda<Func<object, object, object>>(tryCatchMethod2, parameters).Compile();
            object result2 = func2(20, "f"); // result = 100
