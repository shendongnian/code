    var controller = new HomeController();
    var contextMock = new Mock<HttpContext>();
    contextMock.Setup(x => x.User).Returns(new ClaimsPrincipal());
    controller.ControllerContext.HttpContext = contextMock.Object;
    Assert.NotNull(controller.User);
