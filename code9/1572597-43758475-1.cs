    [TestMethod]
    public void TestCreateSms() {
        //Arrange
        var expectedCellNumber = "0734233173";
        var expectedMessage = "Test message";
        var expectedName = "Ronny.Mahlangu";
        var expectedResult = true;
        // - dependency mocked with desired behavior
        var moqDB = new Mock<IDatabaseManager>();
        moqDB
            .Setup(md => md.SendSMS(expectedCellNumber, expectedMessage, expectedName))
            .Returns(expectedResult)
            .Verifiable();
        // - Fake user for request in order to access User.Identity.Name
        var principal = new ClaimsPrincipal(new GenericIdentity(expectedName));
        var contextMock = new Mock<HttpContextBase>();
        contextMock.Setup(_ => _.User).Returns(principal);
        // - controller under test
        var controller = new SmsController(moqDB.Object);
        controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);
        // - view model sent to action
        var tblSend = new SendSMSViewModel {
            CellNumber = expectedCellNumber,
            Message = expectedMessage
        };
        //Act
        var result = controller.CreateSms(tblSend);
        //Assert
        moqDB.Verify(); //verify that the mock executed as expected
        //you can also assert the results of calling the action to confirm expectations
        Assert.IsTrue(controller.TempData.ContainsKey("Success"));
        Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        var redirectResult = result as RedirectToRouteResult;
        Assert.AreEqual("CreateSms", redirectResult.RouteValues["action"]);
    }
