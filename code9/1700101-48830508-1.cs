    [TestMethod]
    public void DoSomeWork_ShouldLogWarning()
    {
        var mockLogger = new Mock<IMyLogger>(MockBehavior.Strict);
        mockLogger.Setup(l => l.Trace(It.IsAny<string>(), It.IsAny<object[]>()));
        var testWorker = new MyWorker(mockLogger.Object);
        const int expectedValue = 5;
        testWorker.DoSomeWork(expectedValue);
        mockLogger.Verify(x => x.Trace($"Value of x is {expectedValue}"));
    }
