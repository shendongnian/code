    public async Task TestMthod() {
        //Arrange
        var expected = "not empty or null string";
        var thirdLevelCacheMock = new Mock<IDatabase>();
        RedisValue val = "not empty or null string";
        thirdLevelCacheMock
            .Setup(m => m.StringGetAsync(It.IsAny<string>(), It.IsAny<CommandFlags>()))
            .ReturnsAsync(val);
        
        var caching = new CachingInfrastructure();
        caching._thirdLevelCache = thirdLevelCacheMock.Object;
        
        //Act
        var result = await caching.GetKeyAsync("bla", CacheLevel.Any);
    
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expected, result);
    }
