    public void Start()
    {
        _system = Akka.Actor.ActorSystem.Create(_settings.SystemName);
        // Create the dependency resolver
        IDependencyResolver resolver = new AutoFacDependencyResolver(IoC.Container, _system);
        PingActor = _system.ActorOf(_system.DI().Props<PingActor>(), ActorNames.PingActor);
        Console.WriteLine($"Starting actor system: {_settings.SystemName}");
    }
