            protected IConfigurationRoot LoadConfiguration()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            // Get the name of the environment this service is running within.
            EnvironmentName = Environment.GetEnvironmentVariable(EnvironmentVariableName);
            if (string.IsNullOrWhiteSpace(EnvironmentName))
            {
                var err = $"Environment is not defined using '{EnvironmentVariableName}'.";
                _logger.Fatal(err);
                throw new ArgumentException(err);
            }
            // Enumerate the configuration packaged. Look for the service type name, service name or settings.
            IList<string> names = Context?.CodePackageActivationContext?.GetConfigurationPackageNames();
            if (null != names)
            {
                foreach (string name in names)
                {
                    if (name.Equals(GenericStatelessService.ConfigPackageName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var newPackage = Context.CodePackageActivationContext.GetConfigurationPackageObject(name);
                        // Set the base path to be the configuration directory, then add the JSON file for the service name and the service type name.
                        builder.SetBasePath(newPackage.Path)                            
                            .AddJsonFile($"{ServiceInstanceName}-{EnvironmentName}.json", true, true)
                            .AddJsonFile($"{Context.ServiceTypeName}-{EnvironmentName}.json", true, true);
                        // Load the settings into memory.
                        builder.AddInMemoryCollection(LoadSettings(newPackage));
                    }
                }
            }
            // Swap in a new configuration.
            return builder.Build();
        }
