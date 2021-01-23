    User GetFirstWhere(Expression<Func<User, bool>> predicate)
    {
    	//get expression body
    	var body = predicate.Body;
    
    	//get if body is logical binary (a == b)
    	if (body.NodeType == ExpressionType.Equal)
    	{
    		var b2 = ((BinaryExpression)body);
    		var rightOp = b2.Right;
    		
    		var methInfo = typeof(SquareSauce).GetMethod("Apply");		
    		var sauceExpr = Expression.Call(methInfo, rightOp);
    		
    		body = Expression.Equal(b2.Left, sauceExpr);
    		predicate = Expression.Lambda<Func<User, bool>>(body, predicate.Parameters);
    	}
    	
    	return user
    		.AsQueryable()
    		.Where(predicate)
    		.FirstOrDefault();
    }
