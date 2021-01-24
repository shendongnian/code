    var _mockLogger = new Mock<ILogger<[YOUR_CLASS_TYPE]>>();
    _mockLogger.Setup(
        m => m.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.IsAny<object>(),
            It.IsAny<Exception>(),
            It.IsAny<Func<object, Exception, string>>()));
    
    var _mockLoggerFactory = new Mock<ILoggerFactory>();
    _mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => _mockLogger.Object);
