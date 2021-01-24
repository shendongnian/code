    class GenericRepository<T> where T : IEntity
    {
        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
