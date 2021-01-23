    public interface IWorker<T>
    {
        Worker<T> GetWorker();
    }
    public class BaseWorker
    {
        public void DoWork() { }
    }
    public class WorkerA : BaseWorker, IWorker<TypeA> {}
    public class WorkerB : BaseWorker, IWorker<TypeB> {}
