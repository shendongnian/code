    [Fact]
    public void Test()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        var mockLog = new Mock<ILog<MyClass>>();
        var mockLogFactory = new Mock<ILogFactory>();
        mockLogFactory.Setup(f => f.CreateLog<MyClass>()).Returns(mockLog.Object);
        serviceCollection.AddSingleton<ILogFactory>(mockLogFactory.Object);
        var myClass = new MyClass();
        myClass.MyMethod(serviceCollection);
        mockLog.Verify(l => l.LogInformation("Hello, World!"), Times.Once);
    }
