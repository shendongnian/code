	var stringGenericInterfaces = typeof(string).GetInterfaces()
		.Where(i => i.IsGenericType)
		.Select(i => i.GetGenericTypeDefinition());
		var extensionsOnGenericInterfaces = from info in
			availableExtensionMethods.Where(aem => aem.FirstParam.ParameterType.ContainsGenericParameters)
			from inter in stringGenericInterfaces
			where info.FirstParam.ParameterType.GetGenericTypeDefinition().IsAssignableFrom(inter)
			select info.Method;
