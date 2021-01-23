    [TestMethod]
    public async Task Y()
    {
        int i = 0;
        await new Task(() => i++);
    
        Assert.AreEqual(1, i);
    }
