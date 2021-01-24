    [TestMethod]
    public void TestMethod1()
    {
        int output = 0;
        Exceptional.Try(() => output = 2 + 2);
        Assert.AreEqual(4, output);
    }
