    public void LoadExtensions()
    {
        IConfigurationSection[] extensionConfigurations = _config.GetSections(EXTENSION_CONFIGURATION_KEY).ToArray();
        if (extensionConfigurations.Length == 0)
            return;
                
        HashSet<IExtension> extensions = new HashSet<IExtension>();
        foreach (IConfigurationSection extensionConfiguration in extensionConfigurations)
        {
            string name = extensionConfiguration.Key;
            string path = _config.Get($"{extensionConfiguration.Path}:path");
    
            _logger.Debug($"Loading extension: {name}");
    
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                throw new ConfigurationItemMissingException($"{extensionConfiguration.Path}:path");
    
            LoadAssembly(path, name);
        }
    
        foreach (var extensionType in _extensionTypes)
        {
            IExtension extension = Activator.CreateInstance(extensionType.Key.AsType(), extensionType.Value, _dependencyUtility) as IExtension;
            if (extension == null)
                throw new InvalidExtensionException(extensionType.Value, extensionType.Key.AssemblyQualifiedName);
    
            extensions.Add(extension);
        }
                
        Extensions = extensions;
    }
    
    private void LoadAssembly(string path, string name)
    {
        FileInfo[] dlls = new DirectoryInfo(Path.GetDirectoryName(path)).GetFiles("*.dll");
    
        foreach (FileInfo dll in dlls)
        {
            Assembly asm = AssemblyLoadContext.Default.LoadFromAssemblyPath(dll.FullName);
    
            _logger.Info($"Loading assembly: {asm.FullName}");
    
            TypeInfo type = asm.DefinedTypes.FirstOrDefault(x => x.ImplementedInterfaces.Contains(typeof(IExtension)) && !x.IsAbstract);
    
            if (type == null)
                continue;
    
            _extensionTypes.Add(type, name);
        }
    }
