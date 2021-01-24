    [TestMethod]
    public void Sample()
    {
        //arrange
        var mockEntityTest = new Mock<DbSet<EntityTest>>();
        var list = new List<EntityTest>();
        var queryable = list.AsQueryable();
        mockEntityTest.As<IQueryable<EntityTest>>().Setup(m => m.Provider).Returns(queryable.Provider);
        mockEntityTest.As<IQueryable<EntityTest>>().Setup(m => m.Expression).Returns(queryable.Expression);
        mockEntityTest.As<IQueryable<EntityTest>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        mockEntityTest.As<IQueryable<EntityTest>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
        var unitOfWork = new  Mock<IUnitOfWork>();
        var valcalContext = new Mock<ValcalContext>();
     
        valcalContext.Setup(vc => vc.Set<EntityTest>()).Returns(mockEntityTest.Object);
        var mock = valcalContext.Object;
        unitOfWork.Setup(uow => uow.Context).Returns(mock);
        var repository = new RepositoryTest(unitOfWork.Object);
        //act
        var entityTests = repository.All;
        //assert
        Assert.AreEqual(entityTests.ToList().Count,0);
    }
