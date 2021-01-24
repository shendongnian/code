    public void WhenCreateAsyncCalledSomePropertyIsSet() {
        // Arrange
        var mockSomeService = new Mock<ISomeService>();
        var someObject = new SomeObject();
        var expected = "SomeValue";
        mockSomeService
            .Setup(x => x.CreateAsync(It.IsAny<SomeObject>()))
            .Callback<SomeObject>(arg => {
                arg.SomeProperty = expected;
            });
        var service = mockSomeService.Object;
        // Act
        service.CreateAsync(someObject);
        var actual = someObject.SomeProperty;
        // Assert
        Assert.NotNull(actual);
        Assert.AreEqual(expected, actual);
    }
