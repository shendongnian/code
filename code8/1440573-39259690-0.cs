    private Mock<IDatabaseConnection> MockOutGetControlDocInfoData()
    {
        return new long[] {  2, 2, 2, 2, 10, 2, 2, 2, 2, 2 }
            .Select(CreateMockCmdObjectWithReturnValue)
            .Aggregate(
                new Mock<IDatabaseConnection>()
                    .SetupAllProperties()
                    .Setup(c => c.Conn.ConnectionString).Returns("What the heck.")
                    .SetupSequence(c => c.CreateCommand(It.IsAny<string>())),
                (mock, cmd) => mock.Returns(cmd.Object)
            );     
    }
