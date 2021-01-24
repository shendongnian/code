    [TestCase("",  typeof(ArgumentException))]
    [TestCase(null, typeof(ArgumentNullException))]
    public void ReturnStatusInvalidArgument(string filePath, Type expectedException)
    {
        Assert.Throws(expectedException, () => Method(filePath));
    }
