    kernel.Bind<SomeConsumerOfProductRepository>().ToSelf();
    kernel.Bind<IProductRepository>().To<productDAL>();
    .
    .
    .
    var consumer = kernel.Get<SomeConsumerOfProductRepository>();
    //Use consumer or do whatever you have to do.... 
