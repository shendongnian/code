    var container = new UnityContainer();
    container.RegisterTypes(
        AllClasses.FromAssembliesInBasePath().Where(
            t => t.Assembly.GetName().Name.StartsWith("SolutionName")),
        WithMappings.FromMatchingInterface,
        WithName.Default,
        WithLifetime.FromMarkerInterface);
    // Singleton
    Debug.Assert(ReferenceEquals(container.Resolve<IPersonRepository>(), container.Resolve<IPersonRepository>()));
    // Transient
    Debug.Assert(!ReferenceEquals(container.Resolve<IPersonService>(), container.Resolve<IPersonService>()));
