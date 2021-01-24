    [TestMethod]
    public void GetSecondColumn_WhenCalled_ReturnsSomeExpectedResult()
    {
        // Arrange
        const string expected = "Expectd Value To Return";
        var rangeMock = new Mock<Range>();
        var fakeResultRange = new Mock<Range>();
        fakeResultRange.Setup(range => range[It.IsAny<object>(), It.IsAny<object>()]).Returns(expected);
        rangeMock.Setup(range => range.Columns).Returns(() => fakeResultRange.Object);
        ClassToUnitTest cut = new ClassToUnitTest();
        // Act
        var actual = cut.GetSecondColumn(rangeMock.Object);
        // Assert
        Assert.AreEqual(expected, actual);
    }	
