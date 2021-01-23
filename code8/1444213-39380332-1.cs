    public void GetTest() {
        //Arrange
        var getTest = new ResourcesController(mockDb);
        //Act
        var result = getTest.Get("1");
        
        //Assert
        var actual = result as OkNegotiatedContentResult<Models.Resource>();
        Assert.NotNull(actual);
        Resource r = actual.Content;
        Assert.NotNull(r);
        Assert.Equal("test", r.Description);
    }
