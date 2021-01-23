    mockLogger.VerifyLog(Times.Once, LogLevel.Critical,It.IsNotNull<Exception>());
 csharp
public static void VerifyLog<T>(this Mock<ILogger<T>> mockLogger, Func<Times> times, LogLevel logLevel, Exception exception)
{
    mockLogger.Verify(
        x => x.Log(
            logLevel,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            exception,
            It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), times);
        }
    public static void VerifyLog<T>(this Mock<ILogger<T>> mockLogger, Func<Times> times)
    {
        mockLogger.VerifyLog(times, It.IsAny<LogLevel>(), It.IsAny<Exception>());
    }
