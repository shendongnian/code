    [TestMethod]
    public void NumberOfMinutesIgnoresSeconds()
    {
        var startTime = TimeSpan.FromSeconds(59).TrimToMinutes();
        var endTime = TimeSpan.FromSeconds(60).TrimToMinutes();
        Assert.AreEqual(1, (endTime - startTime).TotalMinutes);
    }
