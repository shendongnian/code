    //Create test user
    var token = new Mock<IWebToken>();
    var identity = new UserIdentity(token.Object);
    var principal = new GenericPrincipal(identity, roles: new string[] { });
    var user = new ClaimsPrincipal(principal);
    // Set the User on the controller via the ControllerContext
    var messageController = new MessagesController(mesBL.Object) {
        ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = user }
        }
    };
