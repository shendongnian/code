    public void GetTest() {
        //Arrange
        var getTest = new ResourcesController(mockDb);
        //Act
        var result = getTest.Get("1");
        
        //Assert
        var actual = result as OkObjectResult;
        Assert.NotNull(actual);
        
        Resource r = actual.Value as Models.Resource;
        Assert.NotNull(r);
        Assert.Equal("test", r.Description);
    }
