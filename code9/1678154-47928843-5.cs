	ParameterExpression x = Expression.Parameter(typeof(double), "x");
	Expression two = Expression.Constant((double)2);
	Expression halve = Expression.MakeBinary(ExpressionType.Divide, x, two);
	Expression sine = Expression.Call(typeof(Math).GetMethod("Sin"), x);
	Expression sineLambda = Expression.Lambda<Func<double, double>>(sine, x);
	Expression<Func<double, double>> sineHalfLambda = Expression.Lambda<Func<double, double>>(Expression.Invoke(sineLambda, halve), x);
	Func<double, double> sineHalfDelegate = sineHalfLambda.Compile();
