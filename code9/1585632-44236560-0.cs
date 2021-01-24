	public static Delegate CreateLambda(int num)
	{
		var parameters = new ParameterExpression[num];
		
		for (int i = 0; i < num; i++)
		{
			parameters[i] = Expression.Parameter(typeof(int), "p" + i);
		}
		
		// We sum all the parameters together
		Expression sum = parameters[0];
		
		for (int i = 1; i < num; i++)
		{
			sum = Expression.Add(sum, parameters[i]);
		}
		
		Expression body = sum;
		
		LambdaExpression exp = Expression.Lambda(body, parameters);
		return exp.Compile();
	}
