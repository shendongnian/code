    var ioc = new MyIocContainer();
    // register your interfaces and their associated implementation types with the IoC container
    ioc.Register<ISoftwareSession, SoftwareSession>();
    ioc.Register<IRepository, Repository>();
    ioc.Register<IDbContext, MyDbContext>();
    // resolve the IoC container
    ioc.Resolve();
    // get your `ISoftwareSession` instance
    var session = ioc.GetConcrete<ISoftwareSession>();
    var newCar = new Car();
    session.WriteCar(newCar);
