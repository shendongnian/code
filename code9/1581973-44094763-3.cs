    [Fact]
    public async Task TransactionCommit_Logger_ContainsEvent()
    {
        var logger = new FakeLogger();
        var factoryMock = new Mock<ILoggerFactory>();
        factoryMock.Setup(f => f.CreateLogger(It.IsAny<string>()))
            .Returns(logger);
        using (var context = new FooContext(factoryMock.Object))
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                transaction.Commit();
            }
        }
        Assert.True(logger.Events.Contains((int)RelationalEventId.CommittingTransaction));
    }
