    private static TTarget ConvertDelegate<TTarget>(MethodInfo source)
    {
        var targetMethod = typeof(TTarget).GetMethod("Invoke");
        var parameters = targetMethod.GetParameters().Select(p => Expression.Parameter(p.ParameterType, p.Name)).ToArray();
        var methodCall = Expression.Call(source, Expression.NewArrayInit(typeof(object), parameters));
        var delegateExpression = Expression.Lambda<TTarget>(Expression.TypeAs(methodCall, targetMethod.ReturnType), parameters);
        return delegateExpression.Compile();
    }
    
