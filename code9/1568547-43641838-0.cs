    [TestMethod]
    [ExpectedException(typeof(TimeoutException))]
    public async Task HandleAsyncDeleteModel_WhenRepositoryFails_ThrowsException()
    {
        //Arrange
        var token = new CancellationToken();
        var deleteModel = new DeleteProcessCommand(_img, _tnt, _pro, _url);
        var writeRepository = new StubIWriteRepository<Dto>()
        {
            DeleteIfExistsAsyncGuidGuidGuidCancellationToken = (img, tnt, pro, tkn) =>
            { 
                throw new TimeoutException();
            }
        };
        var Logger = new StubILogger();
        var commandHandler = new CommandHandler(Logger, writeRepository, null, null, null, null, null, null);
        //Act
        commandHandler.HandleAsync(deleteModel, token).Wait();
    }
