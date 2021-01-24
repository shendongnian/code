    [TestMethod]
    public void UserSummaryVcTest() {
    
        // Arrange
        var httpContext = new DefaultHttpContext(); //You can also Mock this
        //...then set user and other required properties on the httpContext as needed
        var viewContext = new ViewContext();
        viewContext.HttpContext = httpContext;
        var viewComponentContext = new ViewComponentContext();
        viewComponentContext.ViewContext = viewContext;
    
        var viewComponent = new UserSummaryViewComponent();
        viewComponent.ViewComponentContext = viewComponentContext;
    
        //Act
        var model = viewComponent.Invoke().ViewData.Model as SummaryViewModel;
    
        //Assert
        Assert.AreEqual("UserName", model.UserName);
    } 
