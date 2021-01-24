    [TestMethod()]
    public void LoginTest() {
        var response = _accountController.Login("testuser", "testpw") as OkResult;
        Assert.IsNotNull(response, "User unable to log in with correct login info");
    }
