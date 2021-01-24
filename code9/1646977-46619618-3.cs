    ICompilationAssemblyResolver assemblyResolver = new CompositeCompilationAssemblyResolver
                            (new ICompilationAssemblyResolver[]
        {
        new AppBaseCompilationAssemblyResolver(basePath),       //e.g. project path
        new ReferenceAssemblyPathResolver(defaultReferenceAssembliesPath, fallbackSearchPaths),
        new PackageCompilationAssemblyResolver(nugetPackageDirectory)   //e.g. C:\Users\\{user}\\.nuget\packages
    });
