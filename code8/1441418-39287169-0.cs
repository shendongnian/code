    [TestMethod]
    public void Y()
    {
        int i = 0;
        Task task = new Task(() => i++);
        task.Start();
        task.Wait();
        Assert.AreEqual(1, i);
    }
