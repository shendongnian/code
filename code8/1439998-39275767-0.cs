    [TestMethod]
    public void VerifyWithCallback()
    {
        // Arrange
        bool startsWith = false;
        const string methodName = "methodName";
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        SomeClassWithLogger cut = new SomeClassWithLogger { Logger = mockLogger.Object };
        mockLogger.Setup(l => l.Information(It.IsAny<string>())).Callback<string>(s =>
        {
            startsWith = s.StartsWith("Entering starts with test");
        });
        // Act
        cut.Logger.Information($"Entering starts with test {methodName}");
        // Assert
        Assert.IsTrue(startsWith);
    }
