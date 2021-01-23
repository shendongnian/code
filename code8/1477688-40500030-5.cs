    [Fact]
    public async Task Can_Paginate() {
    
        //Arrange
        var products = GetFakeProducts().ToAsyncDbSetMock();    
        var productCategories = GetFakeProductCategories().ToAsyncDbSetMock();
   
        var customDbContextMock = new Mock<ApplicationDbContext>();
        customDbContextMock.Setup(x => x.Products).Returns(products.Object);
        customDbContextMock.Setup(x => x.ProductCategories).Returns(productCategories.Object);
    
        //...other code removed for brevity
    
        var controller = new ProductsController(customDbContextMock.Object, loggerMock.Object, envMock.Object);
        controller.pageSize = 3;
        controller.ControllerContext = new ControllerContext(actionContext);
        
        //Act
        var result = await controller.List(1, 2);
    
        //Assert
    
        //...other code removed for brevity
    }
