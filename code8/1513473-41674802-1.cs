    // arrange
    var httpRequest = new HttpRequest("", "http://localhost/", "");
    var stringWriter = new StringWriter();
    var httpResponse = new HttpResponse(stringWriter);
    var httpContext = new HttpContext(httpRequest, httpResponse);
    var sessionContainer = new HttpSessionStateContainer(
        "id",
        new SessionStateItemCollection(),
        new HttpStaticObjectsCollection(),
        10,
        true,
        HttpCookieMode.AutoDetect,
        SessionStateMode.InProc,
        false);
    SessionStateUtility.AddHttpSessionStateToContext(httpContext, sessionContainer);
    var controller = new AccountController();
    var requestContext = new RequestContext(new HttpContextWrapper(httpContext), new RouteData());
    controller.ControllerContext = new ControllerContext(requestContext, controller);
    // act
    var actual = controller.Login(new Customer());
    // assert
    ...
