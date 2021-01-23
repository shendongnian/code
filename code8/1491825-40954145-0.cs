    [Fact]
    public void ProductService_DeleteProduct_Test()
    {
        // arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductService_DeleteProduct_Test")
            .Options;
        var product = new Product() { Id = Guid.NewGuid(), Name = "Product"};
        // Insert object using other means, i.e. direct INSERT statement
        // act
        using (var context = new ApplicationDbContext(options))
        {
            var service = new Service(context);
            service.ProductService.DeleteProducts(new List<Guid> { product.Id });
        }
        // assert
        // Execute SELECT COUNT(*) instruction to fetch previously existing row
        Assert.Equal(0, rowsCount);
    }
