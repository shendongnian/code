    [Fact]
    public async Task CreateObject_WhenGoodDtoReceived_SuccessStatusReturned()
    {
        // Arrange
        var mockRepo = new Mock<IYourRepository>();
        mockRepo.Setup(_ => _.Save()).ReturnsAsync(true);//<-- ADD THIS
        var controller = new YourController(mockRepo.Object);
        var objectForCreationDto = new ObjectForCreationDto { Code = "0001", Name = "Object One" };
        // Act
        var result = await controller.CreateObject(objectForCreationDto);
        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
