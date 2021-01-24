        public interface IService
        {
            int RefCount();
        }
        public interface IWorker
        {
        }
        public class ServiceManagement:IService
        {
            IList<IWorker> _workers;
            public ServiceManagement(IList<IWorker> workers)
            {
                _workers = workers ?? new List<IWorker>(0);
            }
            public int RefCount()
            {
                return _workers.Count;
            }
        }
        public class Worker : IWorker
        {
        }
