    var mockLogger = new Mock<ILogger<[YOUR_CLASS_TYPE]>>();
    mockLogger.Setup(
        m => m.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.IsAny<object>(),
            It.IsAny<Exception>(),
            It.IsAny<Func<object, Exception, string>>()));
    
    var mockLoggerFactory = new Mock<ILoggerFactory>();
    mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => mockLogger.Object);
