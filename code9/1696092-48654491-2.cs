    var container = new Container();
    container.Register<ISaysSomething, SaysSomething>();
    container.RegisterConditional<ISayHello, SaysHelloInEnglish>(
        c => c.Consumer.ImplementationType == typeof(SaysSomething));
    container.RegisterConditional<ISayHello, SaysHelloInSpanish>(
        c => c.Consumer.ImplementationType != typeof(SaysSomething))
