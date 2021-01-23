    var mapping = new Dictionary<string, string> {
        { "Col1", "abc" },
        { "Col2", "def" }
    };
    var mockDataReader = new Mock<IDataReader>();
    mockDataReader
        .Setup(m => m[It.IsAny<string>()])
        .Returns<string>(col => mapping[col])
        .Verifiable();
