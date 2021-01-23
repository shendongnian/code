    public sealed class MyClass
    {
        readonly ILog _log;
        public MyClass(ILog log)
        {
            _log = log;
        }
        public void Test()
        {
            _log.WriteLine("Test() called");
        }
    }
