        private Action<RouteCollection> _routeRegistrar;
        private Mock<HttpRequestBase> _mockRequest;
    protected virtual Action<RouteCollection> RouteRegistrar
    {
        get { return _routeRegistrar ?? DefaultRouteRegistrar; }
        set { _routeRegistrar = value; }
    }
    protected Mock<HttpRequestBase> MockRequest
    {
        get
        {
            if (_mockRequest == null)
            {
                _mockRequest = new Mock<HttpRequestBase>();
            }
            return _mockRequest;
        }
    }
    public abstract T TargetController { get; }
    protected void TargetSetup()
    {
        var routes = new RouteCollection();
        RouteRegistrar(routes);
        var responseMock = new Mock<HttpResponseBase>();
        responseMock.Setup(x => x.ApplyAppPathModifier(It.IsAny<string>())).Returns((string url) => url);
        var contextMock = new Mock<HttpContextBase>();
        contextMock.SetupGet(x => x.Request).Returns(MockRequest.Object);
        contextMock.SetupGet(x => x.Response).Returns(responseMock.Object);
        contextMock.SetupGet(x => x.Session).Returns(Mock<HttpSessionStateBase>().Object);
        TargetController.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), Target);
        TargetController.Url = new UrlHelper(new RequestContext(contextMock.Object, new RouteData()), routes);
    }
    protected void DefaultRouteRegistrar(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    }
