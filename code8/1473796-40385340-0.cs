    protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = base.SelectAssemblies();
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var files = directory.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            var modules = files.Where(f => f.Name.Contains("SomeAssemblyNamespacePrefixorProjectName"))
                                      .Select(f => Assembly.LoadFile(f.FullName));
            return assemblies.Concat(modules);
        }
