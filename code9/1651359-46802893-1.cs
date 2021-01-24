    public void Test()
    {
        AppLog.Logger = Substitute.For<ILogger>(); // NSubstitute
        
        SomeMethodToTest();
        
        AppLog.Logger.Recieved(1).LogSomething(...);
    }
