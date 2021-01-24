    builder.RegisterAssemblyTypes(AssemblyUtils.GetAllAssemblies())
    .Where(t => typeof(IReadModelService).IsAssignableFrom(t) ||
    typeof(IDatabaseRepository).IsAssignableFrom(t))
    .AsImplementedInterfaces()
    .InstancePerDependency()
    .PropertiesAutowired();
