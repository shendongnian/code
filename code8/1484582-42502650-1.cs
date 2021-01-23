    var mockProvider = new Mock<IQueryProvider>();
    mockProvider.Setup(s => s.CreateQuery(It.IsAny<MethodCallExpression>()))
        .Returns(null as IQueryable);
    var mockDbSet = new Mock<DbSet<AllReady.Models.ClosestLocation>>();
    mockDbSet.As<IQueryable<AllReady.Models.ClosestLocation>>()
        .Setup(s => s.Provider)
        .Returns(mockProvider.Object);
    var t = mockDbSet.Object;
    context.ClosestLocations = mockDbSet.Object;
    
    var sut = new ClosestLocationsQueryHandler(context);
    var results = sut.Handle(message);
