    var container = new UnityContainer();
    container.Register<IFactory, SomeFactory>(); // Factory is a class in Service.Factory.
    
    // Let your factory project take care of it's registrations as well.
    Service.Factory.Startup.InitContainer(container);
    
    var factory = container.Resolve<IFactory>();
    Service.DataAccess.Interfaces.IDataInterface foo = factory.Create(); 
