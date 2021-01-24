	var scriptOptions = ScriptOptions.Default;
		var asms = AppDomain.CurrentDomain.GetAssemblies(); // .SingleOrDefault(assembly => assembly.GetName().Name == "MyAssembly");
		foreach (Assembly asm in asms)
		{
			scriptOptions = scriptOptions.AddReferences(asm);
		}
		scriptOptions = scriptOptions.AddImports("System");
		scriptOptions = scriptOptions.AddImports("System.Windows");
		Point[] points = await CSharpScript.EvaluateAsync<Point[]>(Code, scriptOptions);
