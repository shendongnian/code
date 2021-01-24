    [Test]
    public void ShouldReturnGS1Available()
    {
        // Arrange
        MockGS1(mockContext, gs1Data);
    
        GS1AIController controller =
            new GS1AIController(mockContext.Object, mockMapper.Object);
    
        // Act
        IActionResult result = controller.Get();
        var okObjectResult = result as OkObjectResult;
        Assert.IsNotNull(okObjectResult);
        var presentations = okObjectResult.Value as IEnumerable<Models.GS1AIPresentation>;
        Assert.IsNotNull(presentations);
    
        // Arrange
        Assert.AreEqual(presentations.Select(g => g.Id).Intersect(gs1Data.Select(d => d.Id)).Count(),
                        presentations.Count());
    }
