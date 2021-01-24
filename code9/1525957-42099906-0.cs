    var dbConnectionMock = new Mock<IDbConnection>();
    dbConnectionMock.Setup(x => x.Open())
                       .Callback(() => {
                               throw new DbException();
                           }).Verifiable();
