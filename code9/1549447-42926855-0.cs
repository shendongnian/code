    [Property("TestCaseId", "001")]
    [Test]
    public void NavigateToSite()
    {
    ...
    }
    [TearDown]
    public void TearDown()
    {
        var testCaseId = TestContext.CurrentContext.Test.Properties["TestCaseId"];
    }
