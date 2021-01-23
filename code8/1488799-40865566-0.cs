     public class Utility
        {
            public static Mock<DbSet<TEntity>> GenerateMockEntity<TEntity>(List<TEntity> entityList) where TEntity : class
            {
                var list = new List<TEntity>();
                list.AddRange(entityList);
                var query = list.AsQueryable();
                var entityMockSet = new Mock<DbSet<TEntity>>() { CallBase = true};
                entityMockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(query.Provider);
                entityMockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(query.Expression);
                entityMockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(query.ElementType);
                entityMockSet.As<IEnumerable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(query.GetEnumerator());
                entityMockSet.Setup(x => x.Add(It.IsAny<TEntity>())).Callback<TEntity>(x => {
                    list.Add(x);
                    entityMockSet.As<IEnumerable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
                }).Returns<TEntity>(x => x);
                return entityMockSet;
            }
        }
