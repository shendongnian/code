    using (var container = new UnityContainer())
    {
      container.RegisterTypes(
        AllClasses.FromLoadedAssemblies(),
        WithMapping.MatchingInterface,
        WithName.Default,
        WithLifetime.ContainerControlled);
    }
