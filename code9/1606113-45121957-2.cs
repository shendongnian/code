    var paramExpress = (from param in paramMatcher
         select Expression.Assign(Expression.Parameter(param.type, param.name),
                    Expression.Constant(param.value, param.type)));
    Func<object> result = Expression.Lambda<Func<object>(Expression.Call(Expression.Constant(this),
        method, paramExpress)).Compile();
