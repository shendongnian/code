    public class MyServiceDouble : IMyService
    {
        public IEnumerable<string> GetSomeData()
        {
            return new [] {"x", "y", "z"};
        }
    }
    public class MyServiceFactoryDouble : IMyServiceFactory
    {
        public IMyService Create()
        {
            return new MyServiceDouble();
        }
        public void Release(IMyService created)
        {
            // Nothing to clean up.
        }
    }
