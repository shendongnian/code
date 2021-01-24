    class DBContext{ }
    
    interface IDoesMethods<TContext> where TContext : new()
    {
        void MethodOne(TContext context = default(TContext));
        void MethodTwo(TContext context = default(TContext));
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
    class MyContextWrapper<TClass, TContext> : IDoesMethods<TContext> where TContext : new() where TClass : IDoesMethods<TContext>, new()
    {
        public void MethodOne(TContext context = default(TContext))
        {
            instance.MethodOne(new TContext());        
        }
        public void MethodTwo(TContext context = default(TContext))
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
