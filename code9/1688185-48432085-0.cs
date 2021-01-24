    [TestClass]
    public class DocumentDBRepositoryShould {
        /// <summary>
        /// Fake IOrderedQueryable IDocumentQuery for mocking purposes
        /// </summary>        
        public interface IFakeDocumentQuery<T> : IDocumentQuery<T>, IOrderedQueryable<T> {
        }
        [TestMethod]
        public async Task ExecuteQueryAsync() {
            //Arrange
            var description = "BBB";
            var expected = new List<MyDocumentClass> {
                new MyDocumentClass{ Description = description },
                new MyDocumentClass{ Description = "ZZZ" },
                new MyDocumentClass{ Description = "AAA" },
                new MyDocumentClass{ Description = "CCC" },
            };
            var response = new FeedResponse<MyDocumentClass>(expected);
            var mockDocumentQuery = new Mock<IFakeDocumentQuery<MyDocumentClass>>();
            mockDocumentQuery
                .SetupSequence(_ => _.HasMoreResults)
                .Returns(true)
                .Returns(false);
            mockDocumentQuery
                .Setup(_ => _.ExecuteNextAsync<MyDocumentClass>(It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);
            var client = new Mock<IDocumentClient>();
            client
                .Setup(_ => _.CreateDocumentQuery<MyDocumentClass>(It.IsAny<Uri>(), It.IsAny<FeedOptions>()))
                .Returns(mockDocumentQuery.Object);
            var cosmosDatabase = string.Empty;
            var documentsRepository = new DocumentDBRepository<MyDocumentClass>(cosmosDatabase, client.Object);
            //Act
            var query = documentsRepository.GetQueryable(); //Simple query.
            var actual = await documentsRepository.ExecuteQueryAsync(query);
            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
