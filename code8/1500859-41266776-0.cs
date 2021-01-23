    ParameterExpression p = Expression.Parameter(typeof(int));
    BinaryExpression b1 = Expression.MakeBinary(ExpressionType.Multiply, p, Expression.Constant(5));//(p*5)
    BinaryExpression b2 = Expression.MakeBinary(ExpressionType.Divide, Expression.Constant(9), Expression.Constant(4));//(9/4)
    BinaryExpression b4 = Expression.MakeBinary(ExpressionType.Add, b1, b2);
    var compiledLambda = (Func<int,int>)Expression.Lambda<Func<int,int>>(b4, new[] {p}).Compile();
    Console.WriteLine(compiledLambda(10)); // Prints 52
    Console.WriteLine(compiledLambda(8));  // Prints 42
