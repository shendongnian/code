    [Fact]
    public void SomeDataTest(
    {
        var serviceUnderTest = new SomeService();
        
        var logger = new Mock<ILogger>();  // Rhino mocks fashion.
        serviceUnderTest.Logger = logger.Object;
       
        var response = serviceUnderTest.Get(new SomeDataClass());
       Assert.NotNull(response);
    }
