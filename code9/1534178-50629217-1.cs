    // https://github.com/aspnet/Caching/blob/45d42c26b75c2436f2e51f4af755c9ec58f62deb/src/Microsoft.Extensions.Caching.Memory/CacheEntry.cs
	var cachEntry = Mock.Of<ICacheEntry>();
	Mock.Get(cachEntry).SetupGet(c => c.ExpirationTokens).Returns(new List<IChangeToken>());
	var mockMemoryCache = Mock.Get(memoryCache);
	mockMemoryCache
		.Setup(m => m.CreateEntry(It.IsAny<object>()))
		.Returns(cachEntry);
