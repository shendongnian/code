    // Arrange
    PostData<object> data = null;
    mock
        .Setup(m => m.IndicesCreate<object>(It.IsAny<string>(), It.IsAny<PostData<object>>(), null))
        .Callback<string, PostData<object>>((s, d) => data = d);
    // Act
    // You test logic
    // Assert
    var stream = new MemoryStream();
    data.Write(stream, fakeSettings);
    var index = Enconding.UTF8.GetString(stream.ToArray());
    index.Should().Be("{ properties: {etc}}");
