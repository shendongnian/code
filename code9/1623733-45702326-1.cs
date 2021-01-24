    public async Task ExampleClass_GetResponses_Should_Return_ResponseArray() {
        //Arrange
        var factoryMock = new Mock<IResponseFactory>();
        factoryMock.Setup(_ => _.FunctionThatCreatesResponse(It.IsAny<RequestObject>()))
                   .Returns(() => Task.FromResult(new ResponseObject()));
    
        var sut = new ExampleClass(factoryMock.Object);
        var arrayOfRequests = new [] { RequestObject1, RequestObject2, RequestObject3 };
        //Act
        var actual = await sut.GetResponses(arrayOfRequests);
    
        //Assert
        Assert.IsNotNull(actual);
        //...assert desired behavior
    }
