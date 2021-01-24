	[Fact]
	public async Task GetAsync_InvalidScope_ReturnsUnauthorizedResult() {
		// Arrange
        var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        var client = _server.CreateClient();
		var url = "api/foo";
		var expected = HttpStatusCode.Unauthorized;
		// Act
		var response = await client.GetAsync(url);
		// Assert
		Assert.AreEqual(expected, response.StatusCode);
	}
	
