    [TestMethod]
    public void Func_ShouldCheckFileExists()
    {
        // Arrange
        var mockFileWrapper = new Mock<IFileWrapper>();
        mockFileWrapper.Setup(_ => _.Exists(It.IsAny<string>())).Returns(true);
        var example = new Example(mockFileWrapper.Object);
        // Act
        int returnValue = example.Func("test path");
        // Assert
        Assert.Equals(returnValue, 1);
    }
