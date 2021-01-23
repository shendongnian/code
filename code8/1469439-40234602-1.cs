    [Test]
    public void ViewDocuments_WhenCalled_ShouldReturnViewModel() {
        // Arrange
        var principal = new CustomPrincipal("2038786");
        principal.UserId = "2038786";
        principal.FirstName = "Test";
        principal.LastName = "User";
        principal.IsStoreUser = true;
    
        var mockUoW = new Mock<IUnitOfWork>();
        //...setup UoW dependency if needed
        var controller = new DocumentsController(mockUoW.Object);
        controller.ControllerContext = new ControllerContext {
            Controller = controller,
            HttpContext = new MockHttpContext(principal)
        };
        // Act
        var result = controller.ViewDocuments();
        //Assert
        //...assertions
    }
