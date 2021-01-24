    // based on https://github.com/autofac/Autofac.Configuration/blob/0f84f3569eb5a59013859f6eaa9b1ea4cf8e77a1/src/Autofac.Configuration/Core/ModuleRegistrar.cs
    public class OptionalModuleRegistrar : IModuleRegistrar
    {
        public virtual void RegisterConfiguredModules(ContainerBuilder builder, IConfiguration configuration)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            var defaultAssembly = configuration.DefaultAssembly();
            foreach (var moduleElement in configuration.GetSection("modules").GetChildren())
            {
                var moduleTypeName = moduleElement["type"];
                var moduleType = GetType(moduleTypeName, defaultAssembly);
                if (moduleType == null)
                {
                    // Log moduleTypeName
                    Console.WriteLine($"{moduleTypeName} module not found");
                    continue;
                }
                var module = (IModule)null;
                using (var moduleActivator = new ReflectionActivator(
                    moduleType,
                    new DefaultConstructorFinder(),
                    new MostParametersConstructorSelector(),
                    moduleElement.GetParameters("parameters"),
                    moduleElement.GetProperties("properties")))
                {
                    module = (IModule)moduleActivator.ActivateInstance(new ContainerBuilder().Build(), Enumerable.Empty<Parameter>());
                }
                builder.RegisterModule(module);
            }
        }
        private Type GetType(String moduleTypeName, Assembly defaultAssembly)
        {
            var moduleType = Type.GetType(moduleTypeName);
            if (moduleType == null && defaultAssembly != null)
            {
                moduleType = defaultAssembly.GetType(moduleTypeName, false, true);
            }
            return moduleType;
        }
    }
