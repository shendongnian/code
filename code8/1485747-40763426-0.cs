    Expression<Func<string, int>> inner = x => int.Parse(x);
    var outer = Expression.Lambda<Func<int>>
                  (Expression.Invoke(inner, Expression.Constant("123")));
    
    outer.Compile()().Dump(); // 123
