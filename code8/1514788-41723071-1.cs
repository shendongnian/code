    public bool check(Expression<Func<Character,bool>> x, Guid guid)
    {
    	var body = x.Body as BinaryExpression;	
    	var g = (Guid) Expression.Lambda(body.Right).Compile().DynamicInvoke();	
        return g == guid;
    }
