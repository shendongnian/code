    [TestMethod]
    public void LoginTest() {
        //Arrange
        var model = new CutomerModel() { Login = "admin", Password = "Password1" };        
        var mockFormsAuthentication = new Mock<IFormsAuthenticationService>();
        
        var controller = new AccountController(mockFormsAuthentication.Object);
    
        //Act
        var actual = controller.Login(model) as ViewResult;
    
        //Assert (using FluentAssertions)
        actual.Should().NotBeNull(because: "the actual result should have the returned view");
        mockFormsAuthentication.Verify(m => m.SignOut(), Times.Once);
    }
