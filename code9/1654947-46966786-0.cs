    [TestMethod]
    [DataRow(10)]
    [DataRow(20)]
    [DataRow(30)]
    public void TestMethod1(int inputValue)
    {
        Assert.AreEqual(10, inputValue);
    }
