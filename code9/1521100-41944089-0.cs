    public async Task TestMthod() {
    
        var thirdLevelCacheMock = new Mock<IDatabase>();
        RedisValue val = "not empty or null string";
        thirdLevelCacheMock
            .Setup(m => m.StringGetAsync(It.IsAny<string>(), It.IsAny<CommandFlags>()))
            .ReturnsAsync(val);
        
        var caching = new CachingInfrastructure();
        caching._thirdLevelCache = thirdLevelCacheMock.Object;
        
        var result = await caching.GetKeyAsync("bla", CacheLevel.Any);
    
        Assert.IsNotNull(result);
    }
