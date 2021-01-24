    Assembly
		.GetExecutingAssembly()
		.GetTypes()
		.Where(_ => _.IsClass)
		.Select(GetDefaultParameterValuesMismatch)
		.Where(_ => _.Count() > 0);
    IEnumerable<(string Interface, string Class, string Method, string Parameter, object InterfaceParameterValue, object ClassParameterValue)>
		GetDefaultParameterValuesMismatch(Type type)
	{
		var interfaceParameterValues = type
			.GetTypeInfo()
			.ImplementedInterfaces
			.SelectMany(i => i.GetMethods().Select(m => new { Type = i.Name, m }))
			.SelectMany(_ => _.m.GetParameters().Select(p => new
			{
				Type = _.Type,
				Method = _.m.Name,
				Parameter = p.Name,
				p.DefaultValue
			}));
		var classParameterValues = type
			.GetTypeInfo()
			.GetMethods()
			.SelectMany(_ => _.GetParameters().Select(p => new
			{
				Type = type.Name,
				Method = _.Name,
				Parameter = p.Name,
				p.DefaultValue
			}));
		return interfaceParameterValues
				.Zip(classParameterValues, (t1, t2) => new { t1, t2 })
                .Where(_ => !object.Equals(_.t1.DefaultValue, (_.t2.DefaultValue)))
				.Select(_ => (Interface: _.t1.Type,
							  Class: _.t2.Type,
							  Method: _.t1.Method,
							  Parameter: _.t1.Parameter,
							  InterfaceParameterValue: _.t1.DefaultValue,
							  ClassParameterValue: _.t2.DefaultValue));
	}
