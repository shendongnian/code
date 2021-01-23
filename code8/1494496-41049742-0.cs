    var itemMock = new Mock<IMyObject>();
    IEnumerable<IMyObject> items = new List<IMyObject> { itemMock.Object };
    var mock = new Mock<IMyCollection>();
    mock.Setup(m => m.Count).Returns(items.Count);
    mock.Setup(m => m[It.Any<int>()]).Returns<int>(i => items[i]);
    mock.Setup(m => m.GetEnumerator()).Returns(() => items.GetEnumerator());
