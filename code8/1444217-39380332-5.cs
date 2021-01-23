    public void GetTest_Given_Id_Should_Return_Resource() {
        //Arrange
        var controller = new ResourcesController(mockDb);
        //Act
        var actionResult = controller.Get("1");
        
        //Assert
        var actual = actionResult as OkObjectResult;
        Assert.NotNull(actual);
        
        var model = actual.Value as Models.Resource;
        Assert.NotNull(model);
        Assert.Equal("test", model.Description);
    }
