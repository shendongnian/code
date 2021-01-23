    Mock<IDataContext> _dataContextMock;
    [TestInitialize]
    public void SetupTest() {
        //DataInitializer.GetAllSearches() returns a List of "Search"
        _searches = DataInitializer.GetAllSearches();
        var queryable = _searches.AsQueryable();
        var dbSet = new Mock<DbSet<Search>>();
        dbSet.As<IQueryable<Search>>().Setup(m => m.Provider).Returns(queryable.Provider);
        dbSet.As<IQueryable<Search>>().Setup(m => m.Expression).Returns(queryable.Expression);
        dbSet.As<IQueryable<Search>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        dbSet.As<IQueryable<Search>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
        dbSet.Setup(d => d.Add(It.IsAny<Search>())).Callback<Search>(_searches.Add);
        _dataContextMock = new Mock<IDataContext>();
        _dataContextMock.Setup(x => x.Searches).Returns(dbSet.Object);
        _dataContextMock.Setup(x => x.Set<Search>()).Returns(dbSet.Object);
        _searchRepository = new SearchRepository(_dataContextMock.Object);
    }
