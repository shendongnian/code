    var container = new Container();
    container.Register<ISimpleDependency, SimpleDependency>();
    container.Register<ISomeOtherDependency, SomeOtherDependency>();
    container.Register<Bar>();
    container.Register<Baz>();
    container.Register<Qux>();
    var fooAReg = Lifestyle.Transient.CreateRegistration<IFoo>(
        () => new Foo(Settings.Default.FooConfigA, container.GetInstance<ISimpleDependency>()),
        container);
    var fooBReg = Lifestyle.Transient.CreateRegistration<IFoo>(
        () => new Foo(Settings.Default.FooConfigB, container.GetInstance<ISimpleDependency>()),
        container);
    // The registrations for IFoo are conditional. We use fooA for Bar and fooB for Baz.
    container.RegisterConditional(typeof(IFoo), fooAReg, 
        c => c.Consumer.ImplementationType == typeof(Bar));
    container.RegisterConditional(typeof(IFoo), fooBReg, 
        c => c.Consumer.ImplementationType == typeof(Baz));
    container.RegisterCollection<IFoo>(new[] { fooAReg, fooBReg });
