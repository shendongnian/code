    var user = CreateLoggedInUser(targetUserID);
            
    mockControllerContext = new Mock<ControllerContext>();
    mockControllerContext.Setup(o => o.HttpContext.User).Returns(user);
          
    myCaseController.ControllerContext = mockControllerContext.Object;
