    public interface IWorker
    {
        bool DidRun<TBasic>(TBasic basic);
    }
    public class WorkerChain
    {
        private readonly List<IWorker> workers = new List<IWorker>
        {
            new Worker(),
            new AnotherWorker()
        };
        public bool DidRun<T>(T basic)
        {
            return workers.Any(worker => worker.DidRun(basic));
        }
    }
    public class Worker : IWorker
    {
        public bool DidRun<T>(T basic)
        {
            if (!(basic is Basic))
            {
                return false;
            }
            Console.WriteLine($"running {basic}");
            return true;
        }
    }
    public class Test
    {
        public void CanRunWorkBasic()
        {
            var didRun = new WorkerChain().DidRun(new Basic());
            Debug.Assert(didRun);
        }
    }
