    class DBContext{ }
    
    interface IDoesMethods<TContext> where TContext : class, new()
    {
        void MethodOne(TContext context = null);
        void MethodTwo(TContext context = null);
    }
    
    class MyClass : IDoesMethods<DBContext>
    {
        public void MethodOne(DBContext context)
        {
        }
        public void MethodTwo(DBContext context)
        {
        }
    }
    class MyContextWrapper<TClass, TContext> : IDoesMethods<TContext> where TContext : class, new() where TClass : IDoesMethods<TContext>, new()
    {
        public void MethodOne(TContext context = null)
        {
            instance.MethodOne(new TContext());        
        }
        public void MethodTwo(TContext context = null)
        {
            instance.MethodTwo(new TContext());
        }
        private TClass instance = new TClass();
    }
    class Program
    {
        static void Main(string[] args)
        {
            var wrapper = new MyContextWrapper<MyClass, DBContext>();
            wrapper.MethodOne();
            wrapper.MethodTwo();
        }
    }
