    [TestMethod]
    public void TestMethod4()
    {
        var controller = new ValuesController();
        dynamic result = controller.GetJson().Data; // returns { id = 1, child = new { id = 12, name = "woop woop" } }
        Assert.AreEqual(1, result.id);
    }
