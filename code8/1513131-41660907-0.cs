    var addinFolder = ...;
    AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
    {
        var missing = new AssemblyName(e.Name);
        var missingPath = Path.Combine(addinFolder, missing.Name + ".dll");
    
        // If we find the DLL in the add-in folder, load and return it.
        if (File.Exists(missingPath))
            return Assembly.LoadFrom(missingPath);
    
        // nothing found, let .NET search the common folders
        return null;
    };
