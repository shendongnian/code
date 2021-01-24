    [Fact]
    public async Task Login_Should_Return_True() { //<-- note the Task and not void
        //Arrange
        var mockClient = new Mock<IHttpClient>();
        mockClient
            .Setup(x => x.PostAsync(It.IsAny<string>(), It.IsAny<string>(), null))
            .ReturnsAsync(new ApiResponse() { StatusCode = HttpStatusCode.OK });
        var api = new ApiService(mockClient.Object);
        //Act
        var response = await api.LoginAsync("", "");
        //Assert
        Assert.IsTrue(response);
    }
