	ParameterExpression x = Expression.Parameter(typeof(double), "x");
	Expression two = Expression.Constant((double)2);
	Expression halve = Expression.MakeBinary(ExpressionType.Divide, x, two);
	Expression sine = Expression.Call(typeof(Math).GetMethod("Sin"), halve);
	Expression<Func<double, double>> sineHalveLambda = Expression.Lambda<Func<double, double>>(sine, x);
