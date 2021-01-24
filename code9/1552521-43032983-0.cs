    // requires "System.Runtime.Loader": "4.0.0",
    public Assembly LoadAssembly(MemoryStream peStream, MemoryStream pdbStream)
    {
        return System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(peStream, pdbStream);
    }
