    [TestMethod]
    public async Task DummyTest() {
        //Arrange
        var mock = new Mock<IGenericRepository>();
        var expected = new List<Product>() { new Product() };
        mock.Setup(_ => _.GetAllAsync<Product>(
             It.IsAny<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(),
             It.IsAny<string>(),
             It.IsAny<int?>(),
             It.IsAny<int?>()
            )).ReturnsAsync(expected);
        var repository = mock.Object;
        //Act
        var actual = await repository.GetAllAsync<Product>(); //<--optional parameters excluded
        //Assert
        CollectionAssert.AreEqual(expected, actual.ToList());
    }
