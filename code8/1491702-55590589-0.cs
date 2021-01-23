    [SetUp]
    public void SetUp()
    {
       _actionContext = new ActionContext()
       {
          HttpContext = new DefaultHttpContext(),
          RouteData = new RouteData(),
          ActionDescriptor = new ActionDescriptor()
       };
    }
