    [Test]
    public void Test_Sanity()
    {
        test = extent.CreateTest("TC_Sanity");
        TestLogin login = new TestLogin(driver);
        login.loginTest();
        test.Info("Login Successful");
        SelectLeaseMenu leasemenu = new SelectLeaseMenu(driver1);
        ...
