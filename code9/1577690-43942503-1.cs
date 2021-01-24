    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public async Task _IsConnectionOk_xxx_RunPing1Command() {
            var dbMock = new Mock<IMongoDatabase>();
            var resultCommand = new BsonDocument("ok", 1);
            dbMock
                .Setup(stub => stub.RunCommandAsync<BsonDocument>(It.IsAny<Command<BsonDocument>>(), It.IsAny<ReadPreference>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(resultCommand)
                .Verifiable();
            var mongoClientMock = new Mock<IMongoClient>();
            mongoClientMock
                .Setup(stub => stub.GetDatabase(It.IsAny<string>(), It.IsAny<MongoDatabaseSettings>()))
                .Returns(dbMock.Object);
            var client = new Client(mongoClientMock.Object);
            var pingCommand = new BsonDocument("ping", 1);
            //act
            var actual = await client.IsConectionOk();
            //assert
            Assert.IsTrue(actual);
            dbMock.Verify();
        }
    }
