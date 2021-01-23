    [TestMethod]
    public void TestValuesController()
    {
        ValuesController controller = new ValuesController();
        controller.ControllerContext = new ControllerContext();
        controller.ControllerContext.HttpContext = new DefaultHttpContext();
        controller.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";
        var result = controller.Get();
        //the controller correctly receives the http header key value pair device-id:20317
        ...
    }
