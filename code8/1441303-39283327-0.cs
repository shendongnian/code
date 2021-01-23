    MyDomain.AssemblyResolve += new ResolveEventHandler(Loader_AssemblyResolve);
    if (System.IO.File.Exists(pathToAssembly) == false)
    {
      System.IO.File.Copy(KnownPathToLastVersion, pathToAssembly)
    }
    _assembly = Assembly.Load(AssemblyName.GetAssemblyName(pathToAssembly));
