    mockLogger.VerifyLog(Times.Once);
 csharp
public static void VerifyLog<T>(this Mock<ILogger<T>> mockLogger, Func<Times> times)
{
    mockLogger.Verify(x => x.Log(
        It.IsAny<LogLevel>(),
        It.IsAny<EventId>(),
        It.Is<It.IsAnyType>((v, t) => true),
        It.IsAny<Exception>(),
        It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), times);
}
