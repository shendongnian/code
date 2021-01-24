	IList list = new ArrayList();
	list.Add(new Dictionary<string, string>
	{
		["key"] = "value"
	});
	list.Add(new Dictionary<string, int>()
	{
		["key"] = 123
	});
	list.Add("just for the test");
	foreach(var it in list)
	{
		foreach(var face in it.GetType().GetInterfaces())
		{
			//1. Filter out non-generic interfaces
			// (following GetGenericTypeDefinition() would throw exception otherwise)
			if (!face.IsGenericType)
				continue;
			//2. Filter out anything that is not IDictionary<,>
			if (typeof(IDictionary<,>) != face.GetGenericTypeDefinition())
				continue;
			//3. Filter out anything that is not IDictionary<string,>
			var generic = face.GetGenericArguments();
			if (typeof(string) != generic[0]) //note: consider IsAssignableFrom instead
				continue;
			//4. Invoke the method
			var valueType = generic[1];
			var method = face.GetMethod("TryGetValue"); //note: needs to be more specific if overloaded
			//don't know how you want to choose R for the Accept<R>
			//method = method.MakeGenericMethod(new[] { typeof(R) });
			var arguments = new object[] { "key", null };
			method.Invoke(it, arguments);
			var value = arguments[1];
			//5. Do something with the result
			Console.WriteLine(value.ToString());
		}
	}
