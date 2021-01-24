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
