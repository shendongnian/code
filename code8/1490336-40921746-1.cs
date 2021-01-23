        AssemblyLoadContext.Default.Resolving += (context, name) =>
        {
            // avoid loading *.resources dlls, because of: https://github.com/dotnet/coreclr/issues/8416
            if (name.Name.EndsWith("resources"))
            {
                return null;
            }
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateLibrary(library, name))
                {
                    return context.LoadFromAssemblyName(new AssemblyName(library.Name));
                }
            }
            var foundDlls = Directory.GetFileSystemEntries(new FileInfo(<YOUR_PATH_HERE>).FullName, name.Name + ".dll", SearchOption.AllDirectories);
            if (foundDlls.Any())
            {
                return context.LoadFromAssemblyPath(foundDlls[0]);
            }
            return context.LoadFromAssemblyName(name);
        };
    }
    private static bool IsCandidateLibrary(RuntimeLibrary library, AssemblyName assemblyName)
    {
        return (library.Name == (assemblyName.Name))
                || (library.Dependencies.Any(d => d.Name.StartsWith(assemblyName.Name)));
    }
