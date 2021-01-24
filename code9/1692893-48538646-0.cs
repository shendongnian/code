    /// <summary>
    /// This sould no be used anywhere except in MyDbContext2
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<SomeTableClass> SomeTable { get; set; }
    }
    /// <summary>
    /// This will be your context in the business-logic
    /// </summary>
    public class MyDbContext2
    {
        private MyDbContext realDb;
        public MyDbContext2(string conStr)
        {
            realDb = new MyDbContext();
        }
        public MyDbSet<SomeTableClass> SomeFakeTable { get; set; }
    }
    /// <summary>
    /// Fake-set with logging
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyDbSet<T> where T : class
    {
        private DbSet<T> dbSet;
        public MyDbSet(DbSet<T> realDbSet)
        {
            this.dbSet = realDbSet;
        }
        public List<T> ToList()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception e)
            {
                // Do some logging..
                throw;
            }
        }
        public T SingleOrDefault()
        {
            try
            {
                return dbSet.SingleOrDefault();
            }
            catch (Exception e)
            {
                // Do some logging..
                throw;
            }
        }
    }
