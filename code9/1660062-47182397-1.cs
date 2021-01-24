    [TestMethod]
    public void GetVerifyLogin_ShouldReturnUser()
    {
        var rServiceClient = Substitute.For<IRServiceClient>();
        rServiceClient.ZipCodeVerifyForXmit("foo").Returns("bar"); // just an example
        var controller = new UserAccountController(rServiceClient);
        var result = controller.GetVerifyLogin("2171251", "2171251");
        Assert.IsNotNull(result);
    }
