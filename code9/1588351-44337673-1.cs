    //Arrange
    var serviceProvider = new Mock<IServiceProvider>();
    serviceProvider
        .Setup(x => x.GetService(typeof(ConfigurationDbContext)))
        .Returns(new ConfigurationDbContext(Options, StoreOptions));
    var serviceScope = new Mock<IServiceScope>();
    serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);
    var serviceScopeFactory = new Mock<IServiceScopeFactory>();
    serviceScopeFactory
        .Setup(x => x.CreateScope())
        .Returns(serviceScope.Object);
    serviceProvider
        .Setup(x => x.GetService(typeof(IServiceScopeFactory)))
        .Returns(serviceScopeFactory.Object);
    var sut = new ApiResourceRepository(serviceProvider.Object);
    //Act
    var actual = sut.Get(myIntValue);
    //Asssert
    //...
