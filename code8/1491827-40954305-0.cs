    public class MyRepository<T> where T: class
    {
        // abbreviated for brevity
    
        public IQueryable<T> GetSomething()
        {
            if (typeof(IAbc).IsAssignableFrom(typeof(T))
            {
                 return GetSomeAbc<T>();
            }
        }
        private IQueryable<V> GetSomeAbc<V>() where V : IAbc
        {
            return DbSet<V>().Where(x => x.Abc == "hey");
        }
    }
