    [TestMethod]
    public void GetLogTypeTest()
    {
        IList<Log> logs = new List<Log>
        {
            new Log() {
                Id = 1,
                Type = "Debug",
                Message = "Test Message"
            }
        };
    
        var logContext = Mock.Create<LogContext>(Constructor.Mocked).PrepareMock();
        logContext.Logs.Bind(logs);
    
        var service = new LogService(logContext);
    
        var debugs = service.GetLogType("Debug");
    
        Assert.AreEqual(1, debugs.Count());
    }
