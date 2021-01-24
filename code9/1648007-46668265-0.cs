    var user = new ClaimsPrincipal();
    var context = new ControllerContext
    {
        HttpContext = new DefaultHttpContext
        {
            User = user
        }
    };
    controllerUnderTest.ControllerContext = context;
