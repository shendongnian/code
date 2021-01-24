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
        //Assuming some class that depends on service and calls mocked method
        var sut = new SudjectCass(mockSomeService.Object);
        // Act
        sut.MethodUnderTest(someObject);
        var actual = someObject.SomeProperty;
        // Assert
        Assert.NotNull(actual);
        Assert.AreEqual(expected, actual);
    }
