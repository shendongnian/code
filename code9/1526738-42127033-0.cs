	Assembly externalAssembly = Assembly.LoadFile("MyAssembly.dll");
	Type externalType = externalAssembly.GetType("Foo.Bar.DataProcessor");
	Type exceptionType = externalAssembly.GetType("Foo.Bar.MyCustomException");
	Object dataProcessorInstance = Activator.CreateInstance();
	MethodInfo method = externalType.GetMethod("ProcessData");
	try
	{
		method.Invoke( dataProcessorInstance, null ); // <-- throws
	}
	catch(System.Exception ex)
	{
		if(!exceptionType.IsAssignableFrom(ex.GetType()))
		{
			throw;
		}
		// handle error gracefully
	}
