    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
    	if (node.Object != null && node.Object.Type == typeof(DateTime))
    	{
    		if (node.Method.Name == "AddHours")
    		{
    			return Expr((DateTime timeValue, double addValue) => 
    				DbFunctions.AddHours(timeValue, (int)addValue).Value)
    				.WithParameters(Visit(node.Object), Visit(node.Arguments[0]));
    		}
    	}
    	return base.VisitMethodCall(node);
    }
