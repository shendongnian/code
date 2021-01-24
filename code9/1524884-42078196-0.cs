    var genericRequestHandlers = typeof(GetAll<>).Assembly
		.ExportedTypes
		.Where(x => IsGenericRequestHandler(x))
		.ToArray();
	foreach (var genericRequestHandler in genericRequestHandlers)
	{
		builder
			.RegisterGeneric(genericRequestHandler)
			.AsImplementedInterfaces();
	}
	private static bool IsGenericRequestHandler(Type t)
	{
		return
			t.IsGenericTypeDefinition &&
			t.GetInterfaces.Any(i =>
			{
				return
					i.IsGenericType &&
					i.GetGenericTypeDefinition == typeof(IRequestHandler<,>);
			});
	}
