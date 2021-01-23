    [TestMethod]
	public async Task TestAsyncHttpCall()
	{
	    var x = await POSTDataHttpContent("test", "http://api/");
		Assert.IsTrue(x.IsSuccessStatusCode);
	}
