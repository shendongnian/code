	public static Func<object[], IMyInterface> BuildFactoryExpression(ConstructorInfo ctor)
	{
		ParameterInfo[] par = ctor.GetParameters(); // Get the parameters of the constructor
		Expression[] args = new Expression[par.Length];
		ParameterExpression param = Expression.Parameter(typeof(object[])); // The object[] paramter to the Func
		for (int i = 0; i != par.Length; ++i)
		{
			// get the item from the array in the parameter and cast it to the correct type for the constructor
			Expression.Convert(Expression.ArrayIndex(param, Expression.Constant(i)), par[i].ParameterType);
		}
		return Expression.Lambda<Func<object[], IMyInterface>>(
			// call the constructor and cast to IMyInterface.
			Expression.Convert(
				Expression.New(ctor, args)
			, typeof(IMyInterface)
			), param
		).Compile();
	}
