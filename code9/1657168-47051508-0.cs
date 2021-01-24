    var mockDatabase = new Mock<StackExchange.Redis.IDatabase>();
    var mockMultiplexer = new Mock<StackExchange.Redis.IConnectionMultiplexer>();
    
    mockMultiplexer
        .Setup(_ => _.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
        .Returns(mockDatabase.Object);
