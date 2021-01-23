    [Test]
    public async Task Get_ReturnsAAListOfBrands() {
        //Arrange
        var mockService = new Mock<IGenericService<Brand>>();
        mockService
            .Setup(repo => repo.GetAll(It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(), It.IsAny<string>()))
            .ReturnsAsync(Brands);
        var controller = new BrandsController(mockService.Object);
        //Act
        var result = await controller.Get();
        //Assert
        //...
    }
