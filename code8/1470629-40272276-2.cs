    protected override Expression VisitMember(MemberExpression node)
    {
    	if (node.Type == typeof(DayOfWeek))
    	{
    		var expr = node.Expression;
    		var firstSunday = new DateTime(1753, 1, 7);
    		var diffDays = Expression.Convert(
    			Expression.Call(
    				typeof(DbFunctions), "DiffDays", Type.EmptyTypes,
    				Expression.Constant(firstSunday, typeof(DateTime?)),
    				Expression.Convert(expr, typeof(DateTime?))),
    			typeof(int));
    		var dayOfWeek = Expression.Convert(
    			Expression.Modulo(diffDays, Expression.Constant(7)),
    			typeof(DayOfWeek));
    		return dayOfWeek;
    	}
    	return base.VisitMember(node);
    }
