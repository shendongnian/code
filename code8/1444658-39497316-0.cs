    static class MockMongoCollection // : IMongoCollection<TDocument>
    {
        private static readonly MongoWriteException __writeException;
        static MockMongoCollection()
        {
            var connectionId = new ConnectionId(new ServerId(new ClusterId(1), new DnsEndPoint("localhost", 27017)), 2);
            var innerException = new Exception("inner");
            var ctor = typeof (WriteConcernError).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
            var writeConcernError = (WriteConcernError)ctor.Invoke(new object[] { 1, "writeConcernError", new BsonDocument("details", "writeConcernError") });
            ctor = typeof (WriteError).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
            var writeError = (WriteError) ctor.Invoke(new object[] {ServerErrorCategory.Uncategorized, 1, "writeError", new BsonDocument("details", "writeError")});
            __writeException = new MongoWriteException(connectionId, writeError, writeConcernError, innerException);
        }
        public static void UpdateOne()
        {
            throw __writeException;
        }
    }
    class ExampleTests
    {
        [Test]
        public void UncategorizedWriteExceptionTest()
        {
            Assert.Throws<MongoWriteException>(MockMongoCollection.UpdateOne);
        }
    }
