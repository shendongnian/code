    // requires "System.Runtime.Loader": "4.0.0",
    protected virtual Assembly LoadAssembly(MemoryStream peStream, MemoryStream pdbStream)
    {
        return System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(peStream, pdbStream);
    }
