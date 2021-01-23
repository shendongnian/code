    void Main()
    {
    	WhatIsThis<string>(x => x.Equals("foo"));
    	Console.WriteLine();
    	WhatIsThis<string>(x => x == "foo");
    }
    
    void WhatIsThis<T>(Expression<Func<T, bool>> expr)
    {
    	Console.WriteLine(expr.Body.NodeType);
    	if (expr.Body is MethodCallExpression)
    	{
    		var ce = expr.Body as MethodCallExpression;
    		Console.WriteLine(ce.Method.Name);
    		Console.WriteLine(ce.Object.ToString());
    		Console.WriteLine(string.Join(", ", ce.Arguments.Select(x => x.ToString())));
    	}
    	else if (expr.Body is BinaryExpression)
    	{
    		var be = expr.Body as BinaryExpression;
    		Console.WriteLine(be.Method.ToString());
    		Console.WriteLine(be.Left.ToString());
    		Console.WriteLine(be.Right.ToString());
    	}
    }
