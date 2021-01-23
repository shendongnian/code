    [AccessControl(Role.Admin)]
    public TestController: Controller {
        ...
    }
    // Dedicated for testing
    [AccessControl(Role.FakeAccess)]
    public PreviewController: TestCoontroller{}
    
