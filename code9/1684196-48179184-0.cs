    var mockCursor = new Mock<IAsyncCursor<Entity>>();
    mockCursor.Setup(_ => _.Current).Returns(expectedEntities); //<-- Note the entities here
    mockCursor
        .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
        .Returns(true)
        .Returns(false);
    mockCursor
        .SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
        .Returns(Task.FromResult(true))
        .Returns(Task.FromResult(false));
    mockMongoCollectionAdapter
        .Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<Entity, bool>>>(),
                null,
                It.IsAny<CancellationToken>()
            ))
        .ReturnsAsync(mockCursor.Object); //<-- return the cursor here.
