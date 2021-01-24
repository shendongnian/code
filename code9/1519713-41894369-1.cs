    [TestMethod]
    public void UserController_EditUser_Should_Be_Valid() {
        // Arrange    
        var _user = new User {
            id = 1,
            name = "User name",
            nickname = "User nickname",
            active = true
        };
        var mockService = new Mock<IUserService>();
        mockService .Setup(m => m.Edit(_user)).Verifiable();
    
        var controller = new UserController(mockService.Object);
        controller.ControllerContext = TestModelHelper.AdminControllerContext();
        // Act
        var result = controller.EditUser(_user) as JsonResult;
        // Assert
        Assert.IsNotNull(result, "Result must not be null");        
        mockService.Verify(); // verify that the service was call successfully. 
    }
