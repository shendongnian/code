    protected override Expression VisitMember(MemberExpression node)
    {
    	if (node.Type == typeof(DayOfWeek))
    	{
    		return Expr((DateTime dateValue1, DateTime dateValue2) => 
    			(DayOfWeek)(DbFunctions.DiffDays(dateValue1, dateValue2).Value % 7))
    			.WithParameters(Constant(new DateTime(1753, 1, 7)), Visit(node.Expression));
    	}
    	return base.VisitMember(node);
    }
