    public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            
            //Find primary key. Here the PK must follow the convention "Class Name" + "Id" 
            Type type = typeof(T);
            string colName = type.Name + "Id";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = type.Name + "ID";
                pk = type.GetProperty(colName);
            }
            dbSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns((object[] id) =>
            {
                var param = Expression.Parameter(type, "t");
                var col = Expression.Property(param, colName);
                var body = Expression.Equal(col, Expression.Constant(id[0]));
                var lambda = Expression.Lambda<Func<T, bool>>(body, param);
                return queryable.FirstOrDefault(lambda);
            });
            return dbSet.Object;
        } //GetQueryableMockDbSet
