    [TestMethod]
    public void HttpBasicAuthorizeAttribute_OnAuthorize_WithAuthorizedUser_ReturnsAuthorization() {
       //Arrange
        var context = new HttpActionContext();
        var headerValue = new AuthenticationHeaderValue("Basic", "bzUwkDal=");
        var request = new HttpRequestMessage();
        request.Headers.Authorization = headerValue;
        var controllerContext = new HttpControllerContext();
        controllerContext.Request = request;
        context.ControllerContext = controllerContext;
       //Act
       ClassUnderTest.OnAuthorization(context);
       //Assert
       //...
    }
