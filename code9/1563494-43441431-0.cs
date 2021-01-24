    // 1. Create a new Simple Injector container
    container = new Container();
    // 2. Configure the container (register)
    container.Register<IRepositoryAsync<Tag>, TagService>();
    container.Register<IRepositoryAsync<Ads>, AdsService>();
    container.Register<IUnitOfWork >();
    // 3. Verify your configuration
    container.Verify();
    //4  
    var service = container.GetInstance<EntityService>();
