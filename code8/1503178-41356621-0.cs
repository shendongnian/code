        var scriptOptions = ScriptOptions.Default;
        //Add reference to mscorlib
        var mscorlib = typeof(System.Object).GetTypeInfo().Assembly;
        var systemCore = typeof(System.Linq.Enumerable).GetTypeInfo().Assembly;
        var references = new[] {mscorlib, systemCore};
        scriptOptions = scriptOptions.AddReferences(references);
        var interactiveLoader = new InteractiveAssemblyLoader();
        foreach (var reference in references)
            interactiveLoader.RegisterDependency(reference);
        //Add namespaces
        scriptOptions = scriptOptions.AddImports("System");
        scriptOptions = scriptOptions.AddImports("System.Linq");
        scriptOptions = scriptOptions.AddImports("System.Collections.Generic");
        var script = CSharpScript.Create(@"", scriptOptions, null, interactiveLoader);
        var state = script.RunAsync().Result;
        state = state.ContinueWithAsync(@"var x = new List<int>(){1,2,3,4,5};").Result;
        state = state.ContinueWithAsync("var y = x.Take(3).ToList();").Result;
        // ...
