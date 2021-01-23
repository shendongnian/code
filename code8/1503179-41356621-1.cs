        var scriptOptions = ScriptOptions.Default;
        // Add reference to mscorlib
        var mscorlib = typeof(object).GetTypeInfo().Assembly;
        var systemCore = typeof(System.Linq.Enumerable).GetTypeInfo().Assembly;
        var references = new[] { mscorlib, systemCore };
        scriptOptions = scriptOptions.AddReferences(references);
        List<int> yList;
        using (var interactiveLoader = new InteractiveAssemblyLoader())
        {
            foreach (var reference in references)
            {
                interactiveLoader.RegisterDependency(reference);
            }
            // Add namespaces
            scriptOptions = scriptOptions.AddImports("System");
            scriptOptions = scriptOptions.AddImports("System.Linq");
            scriptOptions = scriptOptions.AddImports("System.Collections.Generic");
            // Initialize script with custom interactive assembly loader
            var script = CSharpScript.Create(@"", scriptOptions, null, interactiveLoader);
            var state = script.RunAsync().Result;
            state = state.ContinueWithAsync(@"var x = new List<int>(){1,2,3,4,5};").Result;
            state = state.ContinueWithAsync("var y = x.Take(3).ToList();").Result;
            var y = state.Variables[1];
            yList = (List<int>)y.Value;
        }
        foreach (var val in yList)
        {
            Console.Write(val + " "); // Prints 1 2 3
        }
        // ...
