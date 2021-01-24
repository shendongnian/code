    if (order.Type == typeof(DateTime)) // && some other special condition
    {
    	var condition = Expression.GreaterThanOrEqual(
    		order, Expression.Constant(DateTime.Today));
    	var order1 = Expression.Condition(condition,
    		order, Expression.Constant(DateTime.MaxValue));
    	var order2 = Expression.Condition(condition,
    		Expression.Constant(DateTime.MinValue), order);
    	expression = CallOrderBy(expression,
    		Expression.Lambda(order1, parameter), SortDirection.Ascending, initial);
    	expression = CallOrderBy(expression,
    		Expression.Lambda(order2, parameter), SortDirection.Descending, false);
    	initial = false;
    	continue;
    }
