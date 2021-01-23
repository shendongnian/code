    [TestMethod]
    public void Index() {
        //Arange
        Guid? myGuid = new Guid("941b1615-f21b-4e2c-8fa8-0ed0d3f2de53");
        var center = new Center();
        var session = Mock.Of<HttpSessionStateBase>();
        session["Center"] = center;
        var mockSession = Mock.Get(session);
        mockSession.Setup(m => m["Center"]).Returns(center);
        var httpcontext = Mock.Of<HttpContextBase>();
        var httpcontextSetup = Mock.Get(httpcontext);
        httpcontextSetup.Setup(m => m.Session).Returns(session);
        var mockRepository = new Mock<IRepository>();
        mockRepository.Setup(m => m.GetCenter(myGuid.Value)).Returns(center);
        HomeController controller = new HomeController(mockRepository.Object);
        controller.ControllerContext = new ControllerContext {
            HttpContext = httpcontext,
            Controller = controller
        };
        //Act
        ViewResult result = controller.Index(myGuid) as ViewResult;
        //Assert
        Assert.IsNotNull(result);
    }
