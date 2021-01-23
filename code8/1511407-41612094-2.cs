    public async Task Controller_Given_Content_Should_Return_Ok() {
        //Arrange
        var input = "content";
        var mockService = new Mock<IService>();
        mockService
            .Setup(m => m.method(input))
            .ReturnAsync(new Result { Succeeded = true }); 
        var _controller = new Controller(mockService.Object);
    
        //Act
        var result = await _controller.Create(input);
    
        //Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result,typeof(OkResult));
    }
