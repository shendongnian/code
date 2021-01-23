    var parExcep = Expression.Parameter(typeof (Exception), "exc");
    
    MethodInfo excMsg = typeof(Exception).GetProperty("Message",
        BindingFlags.Public | BindingFlags.Instance).GetMethod;
    
    
    TryExpression tryCatchExpr =
        Expression.TryCatch(
            Expression.Block(
                Expression.Throw(Expression.Constant(new DivideByZeroException())),
                Expression.Constant("Try block")
                ),
            Expression.Catch(
                parExcep,
                Expression.Call(parExcep, excMsg)
                )
            );
    Console.WriteLine(Expression.Lambda<Func<string>>(tryCatchExpr).Compile()());
