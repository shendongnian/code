    var UowMock = new Mock<IUnitOfWork<SubscriptionContext>();
    var UowFactoryMock = new Mock<IUowFactory>();
    UowFactoryMock.Stub(f => f.GetUoW()).Returns(UowMock);
    
    var clientManager = new ClientManager(UowFactoryMock);
    // Test whatever you want in your clientManager!
