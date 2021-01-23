    [TestMethod]
    public void TestValuesController()
    {
        ValuesController controller = new ValuesController();
        var result = controller.GetHeaderValue("27");
        Assert.AreEqual(result, "27");
    }
