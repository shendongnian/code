    public DbSet<T> GetDbSet<T>() where T: class
        {
            DbContext db = new DbContext("");
            return db.Set<T>();
        }
        public List<T> GetFilteredData<T>(Expression<Func<T, bool>> criteria) where T : class 
        {
            DbContext db = new DbContext("");
            return db.Set<T>().Where(criteria).ToList();
        }
