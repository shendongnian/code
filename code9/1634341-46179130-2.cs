        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var codeBase = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var serializerPath = Path.Combine(Path.GetDirectoryName(codeBase), new AssemblyName(args.Name).Name + ".dll");
            if (File.Exists(serializerPath))
                return Assembly.LoadFrom(serializerPath);
            else
                return null;
        }
