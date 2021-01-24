    public static IDbSet<T> GenerateSet<T>(IList<T> data) where T : class
        {
            IQueryable<T> queryable = data.AsQueryable();
            IDbSet<T> dbSet = MockRepository.GenerateMock<IDbSet<T>, IQueryable>();
            dbSet.Stub(x => x.Provider).Return(queryable.Provider);
            dbSet.Stub(x => x.Expression).Return(queryable.Expression);
            dbSet.Stub(x => x.ElementType).Return(queryable.ElementType);
            dbSet.Stub(x => x.GetEnumerator()).Return(null).WhenCalled(x => queryable.GetEnumerator());
            return dbSet;
        }
