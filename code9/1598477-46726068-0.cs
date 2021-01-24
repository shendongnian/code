        public IImplementationTypeSelector FromAssemblyDependencies(Assembly assembly)
        {
            Preconditions.NotNull(assembly, nameof(assembly));
            var assemblies = new List<Assembly> { assembly };
            try
            {
                var dependencyNames = assembly.GetReferencedAssemblies();
                foreach (var dependencyName in dependencyNames)
                {
                    try
                    {
                        // Try to load the referenced assembly...
                        assemblies.Add(Assembly.Load(dependencyName));
                    }
                    catch
                    {
                        // Failed to load assembly. Skip it.
                    }
                }
                return InternalFromAssemblies(assemblies);
            }
            catch
            {
                return InternalFromAssemblies(assemblies);
            }
       }
