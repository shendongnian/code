    [Fact]
    public void AutoMoqApiControllerDataAttribute_ContainsCorrectCustomization()
    {
        // Arrange
        var mockFixture = new Mock<IFixture>();
        mockFixture
            .Setup(f => f.Customize(It.IsAny<ApiControllerConventions>()))
            .Returns(mockFixture.Object)
            .Verifiable();
        // Act
        var sut = new AutoMoqApiControllerDataAttribute(mockFixture.Object);
        // Assert
        mockFixture.Verify(
            f => f.Customize(It.IsAny<ApiControllerConventions>()),
            Times.Once());
    }
