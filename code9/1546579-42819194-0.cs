    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        private readonly Func<DbContext> _contextFactory;
        public GenericDataRepository(Func<DbContext> contextFactory) 
        {
            _contextFactory = contextFactory;
        }
    
        public virtual IList<T> Get(Func<T, bool> filter, int page, int pageSize, string[] includePaths = null, params SortExpression<T>[] sortExpressions)
        {
            List<T> list;
            using (var context = contextFactory())
            {
                 //...
            }
         }
    }
