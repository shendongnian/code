    public void WhenCreateAsyncCalledSomePropertyIsSet() {
        // Arrange
        var expected = "SomeValue";
        var mockSomeService = new Mock<ISomeService>();
        mockSomeService
            .Setup(x => x.CreateAsync(It.IsAny<SomeObject>()))
            .Callback<SomeObject>(arg => {
                arg.SomeProperty = expected;
            });
        //Assuming some class that depends on service and calls mocked method
        var sut = new SudjectCass(mockSomeService.Object);
        var someObject = new SomeObject();
        Assert.IsNull(someObject.SomeProperty);        
        // Act
        sut.MethodUnderTest(someObject); //This calls CreateAsync internally.
        var actual = someObject.SomeProperty;
        // Assert
        Assert.NotNull(actual);
        Assert.AreEqual(expected, actual);
    }
