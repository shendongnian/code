    protected override void ConfigureContainer()
    {
        Container.RegisterType<IDepartmentInfoCollectionFactory, DepartmentInfoCollectionFactory>(
                new ContainerControlledLifetimeManager());
  
        this.ConfigureDepartmentInfoCollectionFactory(Container.Resolve<IDepartmentInfoCollectionFactory>());
    }
    private void ConfigureDepartmentInfoCollectionFactory(IDepartmentInfoCollectionFactory factory)
    {
        // Types implementing IDepartmentInfo
        var deptInfoTypes = AppDomain.CurrentDomain
                                        .GetAssemblies()
                                        .SelectMany(s => s.GetTypes())
                                        .Where(t => typeof(IDepartmentInfo).IsAssignableFrom(t)  && !t.IsInterface);
        foreach(Type type in deptInfoTypes)
        {
            // Get collection of BuildingAttribute for the type
            var buildingAttributes = type.GetCustomAttributes(typeof(BuildingAttribute), false)
                                            .OfType<BuildingAttribute>();
                
            if (buildingAttributes.Count() < 1)
                throw new InvalidOperationException(
                    string.Format("The type {0} didn't declare BuildingArgument.", type.ToString()));
                
            var buildingType = buildingAttributes.First().BuildingType;
            if (buildingType == null || !buildingType.GetInterfaces().Contains(typeof(IBuilding)))
                throw new InvalidOperationException(
                    string.Format("{0}: BuildingType is not an IBuilding.", type.ToString()));
            var registerMethod = typeof(IDepartmentInfoCollectionFactory).GetMethod("RegisterDepartment")
                                                                    .MakeGenericMethod(new Type[] { buildingType });
                
            registerMethod.Invoke(factory, new object[]
            {
                new Func<IDepartmentInfo>(() => (IDepartmentInfo)Container.Resolve(type))
            });
        }
    }
