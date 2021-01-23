	var variables = new List<string> { "variableOne", "variableTwo" };
	dynamic scope = new ExpandoObject();
	var dictionary = scope as IDictionary<string, object>;
	foreach (var variable in variables)
		dictionary.Add(variable, null);
	Console.WriteLine(scope.variableOne);
	Console.WriteLine(scope.variableTwo);
