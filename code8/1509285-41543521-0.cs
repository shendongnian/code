    foreach (string parameter in context.ModelState.Keys)
	{
	    string[] parameterParts = parameter.Split('.');
		string argumentName = parameterParts[0];
		string propertyName = parameterParts[1];
		var argument = context.ActionArguments[argumentName];
		var property = argument.GetType().GetProperty(propertyName);
		if (property.IsDefined(typeof(RequiredAttribute), true))
		{
            // Your logic
		}
	}
