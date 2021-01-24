    protected override void ConfigureContainer()
    {
        Container.RegisterType<IDepartmentInfosRegistry, DepartmentInfosRegistry>(new ContainerControlledLifetimeManager());
        this.ConfigureDepartmentInfosRegistry(Container.Resolve<IDepartmentInfosRegistry>());
    }
    private void ConfigureDepartmentInfosRegistry(IDepartmentInfosRegistry registry)
    {
        // Get types implementing IDepartmentInfo
        var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(t => typeof(IDepartmentInfo).IsAssignableFrom(t) && !t.IsInterface);
        foreach(Type type in types)
        {
            // Get building type from the attribute (if multiple was allowed, we would loop through these
            Type buildingType = type.GetCustomAttributes(typeof(BuildingAttribute), false)
                                .OfType<BuildingAttribute>()
                                .First().BuildingType;
            // Add Func to the registry (again for multiple, would be adding more of them)
            registry.RegisterDepartment(buildingType, () => { return (IDepartmentInfo)Container.Resolve(type); });
        }
    }
