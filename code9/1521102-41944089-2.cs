    public async Task TestMthod() {
        //Arrange
        var expected = "not empty or null string";
        var thirdLevelCacheMock = new Mock<IDatabase>();
        RedisValue val = expected;
        thirdLevelCacheMock
            .Setup(m => m.StringGetAsync(It.IsAny<string>(), It.IsAny<CommandFlags>()))
            .ReturnsAsync(val);
        
        var caching = new CachingInfrastructure();
        caching._thirdLevelCache = thirdLevelCacheMock.Object;
        
        //Act
        var actual = await caching.GetKeyAsync("bla", CacheLevel.Any);
    
        //Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual);
    }
