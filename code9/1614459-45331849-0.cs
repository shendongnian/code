    [TestMethod]
    public void TempData_Should_Contain_Message() {    
        // Arrange
        var httpContext = new DefaultHttpContext();
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
        var controller = new TestController();
        controller.TempData = tempData;
    
        // Act
        var result = controller.DoSomething();
    
        //Assert
        controller.TempData["Message"]
            .Should().NotBeNull()
            .And.BeEquivalentTo("Hello World");
    
    }
