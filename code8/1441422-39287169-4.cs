    [TestMethod]
    public void Y()
    {
        int i = 0;
        Task.Run(() => i++).Wait();
        Assert.AreEqual(1, i);
    }
