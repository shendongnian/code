    [TestMethod]
    public void FooConstructorUnitTest()
    {
        // Arrange
        ILogger<FooController> logger = new Logger<FooController>(new NullLoggerFactory());
        // Act
        FooController target = new FooController(logger);
        // Assert
        Assert.AreSame(logger, target.Logger);
    }
