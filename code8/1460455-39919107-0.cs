    public static void RegisterDisposableTransient<TConcrete>(this Container container)
        where TConcrete : class, IDisposable
    {
        var scoped = Lifestyle.Scoped;
        var reg = Lifestyle.Transient.CreateRegistration<TConcrete>(container);
        reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, 
            "suppressed.");
        container.AddRegistration(typeof(TConcrete), reg);
        container.RegisterInitializer<TConcrete>(
            o => scoped.RegisterForDisposal(container, o));
    }
