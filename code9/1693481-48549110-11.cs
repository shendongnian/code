	[TestMethod]
	public async Task JsonRightTest() {
		// Arrange
		var expected = 1;
		
		var model = new MyModelR {
			Title = "foo",
			Body = "bar",
			UserId = 1
		};
		
		var target = new ExternalService(); // System under test
		
		// Act
		var responseModel = await target.PostDataAsync(model);
		
		// Assert
		Assert.IsNotNull(response);
		var actual = responseModel.UserId;
		Assert.AreEqual(expected, actual);
	}
	
