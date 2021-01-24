    public class Repository<T> 
    {
        private DbContext context;
        public ICollection<T> GetAll()
        {            
            var items = context.Set<T>();
            return new EFWrapCollection<T>(items);
        }
    }
