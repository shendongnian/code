    public class TestClass<TEntity>
    {
        private IEnumerable<TEntity> data;
        public TestClass(IEnumerable<TEntity> data){
            OrderBy = (t) => 1;
            ThenOrderBy = (t) => 1;
            this.data = data;
        }
        
        public IEnumerable<TEntity> Get(Func<TEntity, bool> criteria){
            return data.Where(criteria).OrderBy(OrderBy).ThenBy(ThenOrderBy);
        }
        public Func<TEntity, object> OrderBy { get; set; }
        public Func<TEntity, object> ThenOrderBy { get; set; }
    }
