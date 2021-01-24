    public interface IMyService
    {
        IEnumerable<string> GetSomeData();
    }
    public interface IMyServiceFactory
    {
        IMyService Create();
        void Release(IMyService created);
    }
    public class ClassThatConsumesService
    {
        private readonly IMyServiceFactory _serviceFactory;
        public ClassThatConsumesService(IMyServiceFactory myServiceFactory)
        {
            _serviceFactory = myServiceFactory;
        }
        public void MethodThatDoesSomething()
        {
            var service = _serviceFactory.Create();
            try
            {
                var data = service.GetSomeData();
                // do whatever
            }
            finally
            {
                _serviceFactory.Release(service);
            }
        }
    }
