    public static void LoadMoules()
    {            
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string binPath = Path.Combine(basePath, "bin");
        DirectoryInfo binFolder = new DirectoryInfo(binPath);
        IEnumerable<FileInfo> binFiles = binFolder.EnumerateFiles("*.dll", SearchOption.AllDirectories);
        Assembly[] domainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        try
        {
            foreach (var binFile in binFiles)
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(binFile.FullName);
                if (domainAssemblies.All(x => x.FullName != assemblyName.FullName))
                {
                    Assembly.Load(assemblyName.FullName);
                    Debug.WriteLine($"Loading {assemblyName.FullName}");
                }
            }
        }
        catch (Exception exception)
        {
           DynamicModuleLoaderEventSource.Log.FailedToLoadAssembly(exception.Message + exception.StackTrace);
   
        }    }
