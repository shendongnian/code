    public void GetTest_Given_Id_Should_Return_Resource() {
        //Arrange
        var expected = "test";
        var controller = new ResourcesController(mockDb);
        //Act
        var actionResult = controller.Get("1");
        
        //Assert
        var okObjectResult = actionResult as OkObjectResult;
        Assert.NotNull(okObjectResult);
        
        var model = okObjectResult.Value as Models.Resource;
        Assert.NotNull(model);
        var actual = model.Description;
        Assert.Equal(expected, actual);
    }
