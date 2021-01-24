    try
    {
        var exceptions = new List<Exception>();
        target.Initialize(null);
        target.WriteAsyncLogEvent(new LogEventInfo(LogLevel.Info, "Logger1", "message1").WithContinuation(exceptions.Add));
        target.WriteAsyncLogEvent(new LogEventInfo(LogLevel.Info, "Logger1", "message2").WithContinuation(exceptions.Add));
        target.WriteAsyncLogEvents(
            new LogEventInfo(LogLevel.Info, "Logger1", "message3").WithContinuation(exceptions.Add),
            new LogEventInfo(LogLevel.Info, "Logger2", "message4").WithContinuation(exceptions.Add),
            new LogEventInfo(LogLevel.Info, "Logger2", "message5").WithContinuation(exceptions.Add),
            new LogEventInfo(LogLevel.Info, "Logger1", "message6").WithContinuation(exceptions.Add));
        Assert.Equal(6, exceptions.Count);
        target.Close();
    }
    finally
    {
        Console.SetOut(oldConsoleOutWriter);
    }
