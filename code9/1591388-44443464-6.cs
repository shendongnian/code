    public Task WhenCreateAsyncCalledSomePropertyIsSet() {
        // Arrange
        var mockSomeContext = new Mock<ISomeContext>();
        mockSomeContext
            .Setup(x => x.SaveChangesAsync())
            .ReturnsAsync(1); //Because the method under test is async
        var sut = new SomeService (mockSomeContext.Object); //Actual service, fake context
        var someObject = new SomeObject(); //actual object
        Assert.IsNull(someObject.SomeProperty); //making sure it was null to begin with
        // Act
        await sut.CreateAsync(someObject); //call method under test.
        var actual = someObject.SomeProperty; //get the value
        // Assert
        Assert.NotNull(actual); //Assert that it was actually set.
    }
