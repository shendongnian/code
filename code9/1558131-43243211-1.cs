    public class MyClass
    {
        private readonly IRepository<Table001> _table001;
    
        public MyClass(IRepository<Table001> table001)
        {
           _table001 = table001;
        }
    }
