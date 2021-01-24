    public static Mock<DbSet<T>> MockList<T>(this List<T> list) where T: class 
            {
                var mockDbSet = new Mock<DbSet<T>>();
    
                var queryable = list.AsQueryable();
    
                mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
                mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
                mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
                mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
    
                return mockDbSet;
            }
