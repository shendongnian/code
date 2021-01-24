	var myArray = filterCriteria.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                   .ToList();	
	var containsExp = Expression.Call(Expression.Constant(myArray), 
                                        "Contains", null, colExpression.Body);
	if (myArray.Count > 0)
	{
		myQuery = myQuery.Where(Expression.Lambda<Func<TSource, bool>>
                                            (containsExp, colExpression.Parameters));
	}
	return myQuery;
