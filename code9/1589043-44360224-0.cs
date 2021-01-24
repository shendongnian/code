    [TestMethod]
    public async Task GetAccount_Returns_IHttpActionResult() {
        //Arrange
        var accountsService = new Mock<IAccountService>();
        var sut = new AccountsController(accountsService.Object);
        sut.Request = new HttpRequestMessage {
            RequestUri = new Uri("http://localhost/api/accounts?filter=name")
        };
        //Act
        var result = await sut.GetAccount();
        //Assert
        Assert.IsInstanceOfType(result, typeof(IHttpActionResult));
    }
