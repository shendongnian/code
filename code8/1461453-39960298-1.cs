    AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
    {
        // We only want this workaround for one particular DLL
        if (e.Name != "Newtonsoft.Json")
            return null;
        var myLibraryFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.Combine(myLibraryFolder, "Newtonsoft.Json.dll");
    
        return Assembly.LoadFrom(path);
    };
