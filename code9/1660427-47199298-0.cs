    //...code removed for brevity
    var authServiceMock = new Mock<IAuthenticationService>();
    authServiceMock
        .Setup(_ => _.SignInAsync(It.IsAny<HttpContext>(), It.IsAny<string>(), It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
        .Returns(Task.FromResult((object)null));
    var serviceProviderMock = new Mock<IServiceProvider>();
    serviceProviderMock
        .Setup(_ => _.GetService(typeof(IAuthenticationService)))
        .Returns(authServiceMock.Object);
    var controller = new UserController(svc, null) {
        ControllerContext = new ControllerContext {
            HttpContext = new DefaultHttpContext {
                // How mock RequestServices?
                RequestServices = serviceProviderMock.Object
            }
        }
    };
    //...code removed for brevity
