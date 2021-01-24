    public static Mock<DbSet<TEntity>> CreateMockDbSet<TEntity>(IQueryable<TEntity> models) where TEntity : class
    {
        Mock<DbSet<TEntity>> dbSet = new Mock<DbSet<TEntity>>();
        dbSet.As<IQueryable<TEntity>>().Setup(e => e.ElementType).Returns(models.ElementType);
        dbSet.As<IQueryable<TEntity>>().Setup(e => e.Expression).Returns(models.Expression);
        dbSet.As<IQueryable<TEntity>>().Setup(e => e.GetEnumerator()).Returns(models.GetEnumerator());
        dbSet.As<IQueryable<TEntity>>().Setup(e => e.Provider).Returns(models.Provider);
        return dbSet;
    }
