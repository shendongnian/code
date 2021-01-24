    [TestMethod]
    public void _IndexViewTest() {
        //Arrange
        var expectedViewName = "index";
        var controller = ArrangeErrorController(expectedViewName);
        //Act
        var result = controller.Index() as ViewResult;
        //Assert
        Assert.IsNotNull(result);
        //Replicating Framework functionality but
        //This is expected to fail as the view engine is not setup in unit tests.
        try {
            result.ExecuteResult(controller.ControllerContext);
        } catch { }
        //...other code removed for brevity
    }
