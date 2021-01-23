    class Repository<T> : IRepository<T>
    {
        private LibraryContext context;
        public IQueryable<T> All => context.Set<T>().AsQueryable();
        public IQueryable<T> AllNoTracking => context.Set<T>().AsNoTracking();
        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }
        // other methods
    }
