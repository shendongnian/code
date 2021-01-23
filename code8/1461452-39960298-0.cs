    // Do this once when your C# library loads, before calling any method
    // referencing classes from the JSON library.
    AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
    {
        // We only want this workaround for one particular DLL
        if (e.Name != "Newtonsoft.Json")
            return null;
        var myLibraryFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.Combine(myLibraryFolder, "Newtonsoft.Json.dll");
    
        return Assembly.LoadFrom(path);
    };
