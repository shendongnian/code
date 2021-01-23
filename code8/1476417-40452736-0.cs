    [TestMethod]
    public void DoWorkWasCalledWithCorrectParameters()
    {
        var mock = new Moq.Mock<IMyDependency>();
        var myService = new MyService(mock.Object);
        myService.AnotherMethod();
        // verify that method was called once and with correct parameter:
        mock.Verify(x => x.DoWork(myService.MyHandler), Moq.Times.Once);
    }
