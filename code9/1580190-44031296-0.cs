    [Test]
    public void TestMethod()
    {
        Assert.Fail("This test failed");
    }
    [TearDown]
    public void TearDown()
    {
        TestContext.WriteLine(TestContext.CurrentContext.Result.Message);
    }
