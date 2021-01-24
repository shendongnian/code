    [TestCase("12345", ExpectedResult = "SUCCESS")]
    public string ReturnStatusTest_SUCCESS()
    {
        return ReturnsStatus("12345");
    }
    [TestCase("invalidkey", ExpectedException = typeof(ArgumentException))]
    public string ReturnStatusTest_SUCCESS()
    {
        return ReturnsStatus("invalidkey");
    }
    [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
    public string ReturnStatusTest_SUCCESS()
    {
        return ReturnsStatus(null);
    }
    public string ReturnsStatus(string filePath)
    {
        // Arrange
        // Act
        Tuple<string, string> result = service.Create(filePath);
        // Assert
        return result.Item1;
    }
