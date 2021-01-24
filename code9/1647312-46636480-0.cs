        private void LoadAssembly(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException($"Could not find the file \"{path}\"");
            try
            {
                Assembly asm = Assembly.LoadFile(path);
                foreach (IPlugin plugin in asm.GetExportedTypes()
                    .Where(type => typeof(IPlugin).IsAssignableFrom(type) &&
                                   type.GetConstructor(Type.EmptyTypes) != null)
                    .Select(type => Activator.CreateInstance(type) as IPlugin))
                {
                    plugin.Load();
                }
            }
            catch (Exception ex) when (
                ex is FileLoadException ||
                ex is BadImageFormatException)
            {
                // Do something useful
            }
        }
