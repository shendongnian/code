    [TestMethod]
    public void _IMemoryCache_Set_With_Moq() {
        var url = "fakeURL";
        var response = "json string";
        var memoryCache = Mock.Of<IMemoryCache>();
        var cachEntry = Mock.Of<ICacheEntry>();
        var mockMemoryCache = Mock.Get(memoryCache);
        mockMemoryCache
            .Setup(m => m.CreateEntry(It.IsAny<object>()))
            .Returns(cachEntry);
        var cachedResponse = memoryCache.Set<string>(url, response);
        Assert.IsNotNull(cachedResponse);
        Assert.AreEqual(response, cachedResponse);
    }
