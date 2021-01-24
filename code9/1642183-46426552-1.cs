        container.Register<X>(setup: Setup.With(trackDisposableTransient: true));
        // or track globally for all container registrations:
        var container = new Container(rules => rules.WithTrackingDisposableTransients());
        // will be tracked in XUser parent in singleton scope and disposed with container as all singletons
        container.Register<XUser>(Reuse.Singleton);
        container.Register<X>();  
        // or tracking in open scope
        using (var scope = container.OpenScope())
            scope.Resolve<X>; // will be disposed on exiting of using block
