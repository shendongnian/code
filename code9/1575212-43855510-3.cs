    [TestMethod]
    public void PadsNumbersAccordingToParameter()
    {
        var result = new StringRangeCreator().CreateStringRange("abc", 999, 1001, 3).ToList();
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("abc999", result[0]);
        Assert.AreEqual("abc1001", result[2]);
    }
