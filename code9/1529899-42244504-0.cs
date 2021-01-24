    var container = new Container();
    container.RegisterConditional<IAnimal, Cat>(c => c.Consumer.Target.Name == "cat");
    container.RegisterConditional<IAnimal, Dog>(c => c.Consumer.Target.Name == "dog");
    container.RegisterDecorator(typeof(IAnimal), typeof(AnimalSpeakLoudlyDecorator));
    container.Verify();
