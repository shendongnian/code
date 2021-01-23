    public _2A1ControllerTest() {    
        _mockRepository = new Mock<I2A1Repository>();
        var mockUoW = new Mock<IUnitOfWork>();
        mockUoW.SetupGet(u => u._2A1s).Returns(_mockRepository.Object);
    
        var mockViewAsPdf = new Mock<IViewAsPdfWrapper>();
        mockViewAsPdf.Setup(m => m.BuildPdf(It.IsAny<ControllerContext>()))
            .Returns(() => new byte[0]);
    
        _mockRequest = new Mock<HttpRequestBase>();
        _mockHttpContext = new Mock<HttpContextBase>();
        _mockHttpContext.SetupGet(x => x.Request).Returns(_mockRequest.Object);
    
        _controller = new _2A1Controller(mockUoW.Object, mockViewAsPdf.Object);
        _controller.MockCurrentUser("test.admin");
        _controller.ControllerContext = new ControllerContext(_mockHttpContext.Object, new System.Web.Routing.RouteData(), _controller);
    
    }
