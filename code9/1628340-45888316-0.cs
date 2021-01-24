    [TestMethod]
    public void HttpBasicAuthorizeAttribute_OnAuthorize_WithAuthorizedUser_ReturnsAuthorization() {
       //Arrange
       var context = new Mock<HttpActionContext>();
       var headerValue = new AuthenticationHeaderValue("Basic", "bzUwkDal=");
       context.Setup(x => x.Request.Headers.Authorization).Returns(headerValue);
       //Act
       ClassUnderTest.OnAuthorization(context.Object);
       //Assert
       //...
    }
