    Assembly
		.GetExecutingAssembly()
		.GetTypes()
		.Where(t => t.IsClass)
		.Select(GetDefaultParameterValuesMismatch)
		.Where(m => m.Count() > 0);
    IEnumerable<(string Interface, string Class, string Method, string Parameter, object InterfaceParameterValue, object ClassParameterValue)>
		GetDefaultParameterValuesMismatch(Type type)
	{
		var interfaceParameterValues = type
			.GetTypeInfo()
			.ImplementedInterfaces
			.SelectMany(i => i.GetMethods().Select(m => new { Type = i.Name, m }))
			.SelectMany(t => t.m.GetParameters().Select(p => new
			{
				Type = t.Type,
				Method = t.m.Name,
				Parameter = p.Name,
				p.DefaultValue
			}));
		var classParameterValues = type
			.GetTypeInfo()
			.GetMethods()
			.SelectMany(m => m.GetParameters().Select(p => new
			{
				Type = type.Name,
				Method = m.Name,
				Parameter = p.Name,
				p.DefaultValue
			}));
		return interfaceParameterValues
				.Zip(classParameterValues, (t1, t2) => new { t1, t2 })
				.Where(typePair => !object.Equals(typePair.t1.DefaultValue, (typePair.t2.DefaultValue)))
				.Select(typePair => (Interface: typePair.t1.Type,
							  Class: typePair.t2.Type,
							  Method: typePair.t1.Method,
							  Parameter: typePair.t1.Parameter,
							  InterfaceParameterValue: typePair.t1.DefaultValue,
							  ClassParameterValue: typePair.t2.DefaultValue));
	}
