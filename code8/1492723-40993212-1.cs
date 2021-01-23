	var createPropertyMethod = typeof(DynamicPropertyManager<ThreeColumns>).GetMethods().Single(x =>
	{
		var p = x.GetParameters();
		var g = x.GetGenericArguments();
		return x.Name == "CreateProperty" &&
			p.Length == 3 &&
			g.Length == 2 &&
			p[0].ParameterType == typeof(string) &&
			p[1].ParameterType == typeof(Func<,>).MakeGenericType(g) &&
			p[2].ParameterType == typeof(Attribute[]);
	});
	var closedMethod = createPropertyMethod.MakeGenericMethod(new [] { typeof(ThreeColumns), typeof(string) });
	var ret = closedMethod.Invoke(null, new object[] { "Four" , new Func<ThreeColumns, string>(t => "Four"), null });
