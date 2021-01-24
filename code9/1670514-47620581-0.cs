    var playerTypes = var registrations = container
        .GetTypesToRegister(typeof(IPlayer), assemblies);
    foreach (Type playerType in playerTypes)
    {
        container.Register(playerType, Lifestyle.Singleton);
    }
    container.RegisterCollection<IPlayer>(assemblies);
    container.RegisterCollection<ISongAware>(assemblies);
