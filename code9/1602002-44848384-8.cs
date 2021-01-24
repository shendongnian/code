    public class MyService
    {
        private readonly IMyClass _myClass;
    
        public MyService(IMyClass myClass)
        {
            _myClass = myClass;
        }
    
        public void DoSomething()
        {
            _myClass.DoSomething();
        }
    }
    public interface IMyClass
    {
        void DoSomething();
    }
    public class MyClass : IMyClass
    {
        private readonly IDataContext _context;
        public MyClass(IDataContext context)
        {
            _context = context;
        }
        public void DoSomething()
        {
            _context.SaveSomeData();
        }
    }
