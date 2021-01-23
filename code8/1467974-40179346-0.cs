	foreach (var f in g.GetFields()) {
		var ft = f.FieldType;
		if (!ft.IsGenericType) continue;
		var da = ft.GetGenericArguments();
		if (da.Any(xt => a.Contains(xt))) {
			Console.WriteLine("Field {0} uses generic type parameter", f.Name);
		} else {
			Console.WriteLine("Field {0} does not use generic type parameter", f.Name);
		}
	}
