    //Create fake claim
    var fakeClaim = A.Fake<Claim>(x => x.WithArgumentsForConstructor(() => new Claim(ClaimTypes.NameIdentifier, "1")));
    var fakeIdentity = A.Fake<ClaimsPrincipal>();
    
    //Fake IHttpContextAccessor in IdentityService
    var httpContextAccessor = A.Fake<HttpContextAccessor>();
    httpContextAccessor.HttpContext = A.Fake<HttpContext>();
    httpContextAccessor.HttpContext.User = A.Fake<ClaimsPrincipal>();
    A.CallTo(() => httpContextAccessor.HttpContext.User.Identity.IsAuthenticated).Returns(true);
    A.CallTo(() => httpContextAccessor.HttpContext.User.Claims).Returns(new List<Claim> { fakeClaim });
    var identityService = new IdentityService(httpContextAccessor);
    
    //Fake HttpContext in Controller
    _userController = new UserController(localizer, Mapper, UserService, StatusService, identityService);
    _userController.ControllerContext = A.Fake<ControllerContext>();
    _userController.ControllerContext.HttpContext = A.Fake<DefaultHttpContext>();
    
    A.CallTo(() => _userController.ControllerContext.HttpContext.User).Returns(fakeIdentity);
    A.CallTo(() => _userController.ControllerContext.HttpContext.User.Identity.Name).Returns("test");
    A.CallTo(() => _userController.ControllerContext.HttpContext.User.Claims).Returns(new List<Claim> { fakeClaim});
