    [Test]
    public void Test_MyController_PostAction()
    {
        var controller = new MyController();
        ActionResult result = controller.PostAction(new SomeModel()); // Just pass as parameter
        
        // Assert here
    }
