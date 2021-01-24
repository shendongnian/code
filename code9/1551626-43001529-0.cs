    [TestMethod]
    public async Task DummyTest() {
        //Arrange
        var mock = new Mock<IGenericRepository>();
        var list = new List<Product>() { new Product() };
        mock.Setup(_ => _.GetAllAsync<Product>(
             It.IsAny<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(),
             It.IsAny<string>(),
             It.IsAny<int?>(),
             It.IsAny<int?>()
            )).ReturnsAsync(list);
        var repository = mock.Object;
        //Act
        var actual = await repository.GetAllAsync<Product>(q => { return q.OrderBy(p => p); });
        //Assert
        CollectionAssert.AreEqual(list, actual.ToList());
    }
