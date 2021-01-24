    [TestMethod()]
    public void MyTestMethod()
    {
        // Create test input data
        SomeModel TestModel = new SomeModel();
        TestModel.Value = 1;
        // Create mocked data layer
        var FakeDataLayer = new Mock<IMyDataLayer>();
        FakeDataLayer.Setup(x => x.UploadToDb(It.IsAny<SomeModel>()).Returns(TestValueIWantReturned);
        // Create controller using fake data service
        var controller = new MyController(interface);
        // Controller function call
        var result = controller.SomeAction() as ViewResult;
        
        // Assert stuff
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Model);
        // ...
        
    }
