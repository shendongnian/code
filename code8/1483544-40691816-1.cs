    public interface IWorker<T>
    {
        IWorker<T> GetWorker();
    }
    public class BaseWorker
    {
        public void DoWork() { }
    }
    public class WorkerA : BaseWorker, IWorker<TypeA> {}
    public class WorkerB : BaseWorker, IWorker<TypeB> {}
