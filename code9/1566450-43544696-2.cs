    [TestMethod]
    [Description("Should Print")]
    public void PrintDetailsSuccess()
    {
        mainPage.PrintDetails(driver);
        Thread.Sleep(300);
        bool errorMessagePresent = WaitForNoErrorMsg(driver);
        Assert.IsFalse(errorMessagePresent);
    }
