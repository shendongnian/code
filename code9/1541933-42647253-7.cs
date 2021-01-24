    [TestMethod]
    public async Task GetUserByUserName() {
        //Arrange
        var client = MockRestClient<User>(HttpStatusCode.OK, "my json code");
        var dataServices = new DataServices(client);
        //Act
        var user = await dataServices.GetUserByUserName("User1");
        //Assert
        Assert.AreEqual("User1", user.Username);
    }
