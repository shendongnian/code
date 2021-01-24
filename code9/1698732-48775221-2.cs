    var assemblies = AppDomain.CurrentDomain.GetAssemblies().
            Where(assembly => assembly.GetName().Name.Contains("MyAssemblyName"));
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(t => t.IsClass && t.IsPublic && t.Name.Contains("Installer")); // You can create your own convention here, make sure it won't conflict with other class names that are not meant to be installers
                foreach (var installerType in types)
                {
                    LoadInstaller(installerType, services);
                }
            }
