    public abstract class JobBase<T> : IJob<T> where T : IData {
        public JobBase(T data) {
            JobData = data;
        }
        public T JobData { get; private set; }
        public abstract void Run();
    }
