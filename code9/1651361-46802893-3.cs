    public void Test()
    {
        AppLog.Logger = Substitute.For<ILogger>(); // NSubstitute
        
        var logMock = new Mock<ILogger>();         // Moq
        AppLog.Logger = logMock.Object;            // Moq 
        
        SomeMethodToTest();
        
        AppLog.Logger.Recieved(1).LogSomething(...); // NSubstitute
        
        logMock.Verify(x => x.LogSomething(...));    // Moq
    }
