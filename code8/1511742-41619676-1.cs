	var type_str = "Circle";
	// TypeChache should be static field
	if (TypeChache == null)
	{
		var assem = Assembly.GetExecutingAssembly();
		TypeChache = assem.GetTypes()
					 .Where(x => typeof(Shape).IsAssignableFrom(x))
					 .ToDictionary(x=>x.Name, x=>x);
	}
	
	var type = TypeChache[type_str];	
	var inst = (Shape) Activator.CreateInstance(type);
	DoSomething(inst);
