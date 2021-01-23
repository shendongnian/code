    [Fact]
    public async Task GetCompanyProductURLAsync_ReturnsNullForInvalidCompanyProduct()
    {
        var companyProducts = Enumerable.Empty<CompanyProductUrl>().AsQueryable();
        var mockSet = new Mock<DbSet<CompanyProductUrl>>();
        mockSet.As<IAsyncEnumerable<CompanyProductUrl>>()
            .Setup(m => m.GetEnumerator())
            .Returns(new TestAsyncEnumerator<CompanyProductUrl>(companyProducts.GetEnumerator()));
        mockSet.As<IQueryable<CompanyProductUrl>>()
            .Setup(m => m.Provider)
            .Returns(new TestAsyncQueryProvider<CompanyProductUrl>(companyProducts.Provider));
        mockSet.As<IQueryable<CompanyProductUrl>>().Setup(m => m.Expression).Returns(companyProducts.Expression);
        mockSet.As<IQueryable<CompanyProductUrl>>().Setup(m => m.ElementType).Returns(companyProducts.ElementType);
        mockSet.As<IQueryable<CompanyProductUrl>>().Setup(m => m.GetEnumerator()).Returns(() => companyProducts.GetEnumerator());
        var contextOptions = new DbContextOptions<SaasDispatcherDbContext>();
        var mockContext = new Mock<SaasDispatcherDbContext>(contextOptions);
        mockContext.Setup(c => c.Set<CompanyProductUrl>()).Returns(mockSet.Object);
        var entityRepository = new EntityRepository<CompanyProductUrl>(mockContext.Object);
            
        var service = new CompanyProductService(entityRepository);
        var result = await service.GetCompanyProductURLAsync(Guid.NewGuid(), "wot", Guid.NewGuid());
        Assert.Null(result);
    }
