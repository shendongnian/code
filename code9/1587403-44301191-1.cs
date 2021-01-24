    [TestMethod]
    public void TestMethod1()
    {
        RegisterBindingModel model = new RegisterBindingModel();
        var logService = MockFactory.ReturnMockLoggingService();
        var userService = MockFactory.ReturnMockUserService();
        AccountController ac = new AccountController(userService, logService);
        model.UserName = "test123@gmail.com";
        var result = ac.Register(model);
        Assert.AreEqual("User Registered Successfully", result);
    }
