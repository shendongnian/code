    MockLogger.Verify(m => m.Log(
        LogLevel.Error,
        It.IsAny<EventId>(),
        It.Is<FormattedLogValues>(v => v.ToString().Contains("CreateInvoiceFailed")),
        It.IsAny<Func<TState, Exception, string>>()));
