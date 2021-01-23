    var argX = Expression.Parameter(typeof(double), "x");
	var f = Expression.Add(argX, Expression.Constant(3.0)); // applies to x => x + 3
	var g = Expression.Add(argX, Expression.Constant(2.0)); // applies to x => x + 2
	var fg = Expression.Multiply(f, g); // applies to f(x) * g(x)
	var lambda = Expression.Lambda<Func<double, double>>(fg, argX);
