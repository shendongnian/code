    public static class DbSetExtensions
    {
        public static DbSet<T> MockFromSql<T>(this DbSet<T> dbSet, SpAsyncEnumerableQueryable<T> spItems) where T : class
        {
            var queryProviderMock = new Mock<IQueryProvider>();
            queryProviderMock.Setup(p => p.CreateQuery<T>(It.IsAny<MethodCallExpression>()))
                .Returns<MethodCallExpression>(x => spItems);
    
            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>()
                .SetupGet(q => q.Provider)
                .Returns(() => queryProviderMock.Object);
    
            dbSetMock.As<IQueryable<T>>()
                .Setup(q => q.Expression)
                .Returns(Expression.Constant(dbSetMock.Object));
            return dbSetMock.Object;
        }
    }
