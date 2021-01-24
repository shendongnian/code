    [TestMethod]
    public async Task TestMethod1()
    {
        _mockI2.Setup(x => x.RunAsync()).Returns(Task.FromResult(true));
        await _bInstance.Method1();
        _mockI2.Verify(x => x.RunAsync(), Times.Once);           
    }
