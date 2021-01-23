    public void NaiveTest()
    {
        var key = "someKey";
        var result = "someValue";
        var mockConfigurationService = new Mock<IConfigurationService>();
        mockConfigurationService.Setup(x => x.Get(key)).Returns(result);
       // pass service to class being tested and continue
    }
