    public abstract class JobBase<T> : IJob<T> where T : IData {
        public JobBase() {
            JobData = GetData();
        }
        public T JobData { get; private set; }
        public abstract void Run();
        public abstract T GetData();
    }
