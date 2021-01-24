	var fooAProd = Lifestyle.Transient.CreateProducer<IFoo>(
		() => new Foo(Settings.Default.FooConfigA, container.GetInstance<ISimpleDependency>()),
		container);
	var bar1Reg = Lifestyle.Transient.CreateRegistration<Bar>(() => new Bar(
		fooAProd.GetInstance(),
		container.GetInstance<IOtherDep1>()));
		
	var fooBProd = Lifestyle.Transient.CreateProducer<IFoo>(
		() => new Foo(Settings.Default.FooConfigB, container.GetInstance<ISimpleDependency>()),
		container);
		
	var bar2Reg = Lifestyle.Transient.CreateRegistration<Bar>(() => new Bar(
		fooBProd.GetInstance(),
		container.GetInstance<IOtherDep1>()));
	// The registrations for IFoo are conditional. We use fooA for Bar and fooB for Baz.
	container.RegisterConditional(typeof(IFoo), fooBProd.Registration, 
		c => c.Consumer.ImplementationType == typeof(Baz));
	container.RegisterCollection<IFoo>(new[] { fooAReg, fooBReg });
