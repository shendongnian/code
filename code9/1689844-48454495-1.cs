    [TestMethod]
    public async Task Index_ClientTypeIsRPI_ExpectCorrectRedirect() {
        //Arrange
        var mock = new MockRepository(MockBehavior.Loose) {
            DefaultValue = DefaultValue.Mock,
        };
        var session = new HttpSessionStateMock();//<-- session stub
        var controllerContext = mock.Create<ControllerContext>();
        controllerContext.Setup(_ => _.HttpContext.Session).Returns(session);
        var _controller = new MyController() {
            ControllerContext = controllerContext.Object
        };
        var transNo = "Asdf";
        var clientID = "123";
        var clientType = "RPI";
        var sessionKey = "REDIRECT_TO";
        var expected = "www.reddit.com";
        //Act
        await _controller.Index(transNo, true, clientID, clientType);
        var actual = _controller.HttpContext.Session[sessionKey].ToString();
        //Assert
        Assert.AreEqual(expected, actual);
    }
