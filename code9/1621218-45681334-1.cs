            var dllFiles = Directory.GetFiles(DIR, "*.DLL", SearchOption.AllDirectories);
            var plugins = new HashSet<Assembly>();
            var references = typeof(Program).Assembly.GetReferencedAssemblies();
            foreach (var dllPath in dllFiles)
            {
                string name = Path.GetFileNameWithoutExtension(dllPath);
                if (!references.Any(x => x.Name == name) && !plugins.Any(x => x.GetName().Name == name))
                    plugins.Add(Assembly.LoadFrom(dllPath));
            }
    
