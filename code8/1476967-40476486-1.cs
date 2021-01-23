	var genericType = t.MakeGenericType(typeof(int));
	var tObj = Activator.CreateInstance(genericType);
	
	var method = genericType.GetMethods()
		.Where(m => m.Name == "Equals" && m.DeclaringType == genericType)
		.First();
	
	method.Invoke(tObj, new object[] { 5 });
