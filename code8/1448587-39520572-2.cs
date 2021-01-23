    [TestMethod]
	public async void TestAsyncHttpCall()
	{
	    var x = await POSTDataHttpContent("test", "http://api/");
		Assert.IsTrue(x.IsSuccessStatusCode);
	}
