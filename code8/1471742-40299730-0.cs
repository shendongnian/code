    var builder = new ContainerBuilder();
    var userInput = ReadInput();
    if(userInput = "json")
        builder.Register<IRepository>(c => new JsonRepository("dbidentifier"));
    else
        builder.Register<IRepository>(c => new MemoryRepository());
    builder.RegisterType<BeerShop>.As<IShopService>();
    var container = builder.build();
    [...]    
    var service = container.Resolve<IShopService>();
