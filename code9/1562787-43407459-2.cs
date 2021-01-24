    class RoleIdentifiedRepositoryBase<T> : GenericRepository<T>
        where T : IRoleIdentifiedEntity
    {
        public IEnumerable<T> Query(int id)
        {
            return Query(e => e.RoleID == id);
        }
    }
