        [Test]
        public void GivenADuplicateKeyWriteErrorOccurs_WhenCallingUpdateOne_ThenNoExceptionIsThrown()
        {
            // Given
            var someMongoService = CreateSomeObject();
            _mockMongoCollection.Setup(x => x.UpdateOne(It.IsAny<FilterDefinition<SomeObject>>(), It.IsAny<UpdateDefinition<SomeObject>>(), It.IsAny<UpdateOptions>(), default(CancellationToken))).Throws(CreateMongoWriteException(ServerErrorCategory.DuplicateKey));
            // When / Then
            Assert.DoesNotThrow(() => someMongoService.Upsert(new CreateNewSomeObject());
        }
        [Test]
        public void GivenAExceptionOccursWhichIsNotADuplicateKeyWriteError_WhenCallingUpdateOne_ThenTheExceptionIsThrown()
        {
            // Given
            var someMongoService = CreateFilterService();
            var exception = CreateMongoWriteException(ServerErrorCategory.ExecutionTimeout);
            _mockMongoCollection.Setup(x => x.UpdateOne(It.IsAny<FilterDefinition<SomeObject>>(), It.IsAny<UpdateDefinition<SomeObject>>(), It.IsAny<UpdateOptions>(), default(CancellationToken))).Throws(exception);
            // When / Then
            Assert.Throws<MongoWriteException>(() => someMongoService.Upsert(new CreateNewSomeObject());
        }
        public static MongoWriteException CreateMongoWriteException(ServerErrorCategory serverErrorCategory)
        {
            var connectionId = new ConnectionId(new ServerId(new ClusterId(1), new DnsEndPoint("localhost", 27017)), 2);
            
            var writeConcernError = CreateWriteConcernError();
            var writeError = CreateWriteError(serverErrorCategory);
            return new MongoWriteException(connectionId, writeError, writeConcernError, new Exception());
        }
        private static WriteError CreateWriteError(ServerErrorCategory serverErrorCategory)
        {
            var ctor = typeof (WriteError).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
            var writeError = (WriteError)ctor.Invoke(new object[] {serverErrorCategory, 1, "writeError", new BsonDocument("details", "writeError")});
            return writeError;
        }
        private static WriteConcernError CreateWriteConcernError()
        {
            var ctor = typeof(WriteConcernError).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
            return (WriteConcernError)ctor.Invoke(new object[] { 1, "writeConcernError", new BsonDocument("details", "writeConcernError") });
        }
