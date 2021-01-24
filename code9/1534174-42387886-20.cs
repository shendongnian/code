	[TestMethod]
	public void _IMemoryCacheTestWithMoq() {
		var url = "fakeURL";
		object expected = null;
		var memoryCache = MockMemoryCacheService.GetMemoryCache(expected);
		var cachedResponse = memoryCache.Get<string>(url);
		Assert.IsNull(cachedResponse);
		Assert.AreEqual(expected, cachedResponse);
	}
