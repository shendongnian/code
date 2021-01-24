    var container = new WindsorContainer();
    container.Register(
        Component.For<ISaysHello, SaysHelloInSpanish>().IsDefault(),
        Component.For<ISaysHello, SaysHelloInEnglish>().Named("English"),
        Component.For<ISaysSomething, SaysSomething>()
            .DependsOn(Dependency.OnComponent(typeof(ISaysHello),"English")));
