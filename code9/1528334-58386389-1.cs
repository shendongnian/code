	var assemblyOne = Assembly.GetAssembly(typeof(IMyRepository));
	var assemblyTwo = Assembly.GetAssembly(typeof(IMyBusinessLogic));
	var assemblyThree = Assembly.GetExecutingAssembly();
	AddTransientsByConvention(services,
        new [] { assemblyOne, assemblyTwo , assemblyThree },
		x => x.Namespace.StartsWith("CompanyName"));
