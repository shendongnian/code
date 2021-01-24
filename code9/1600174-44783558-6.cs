    public abstract class JobBase<T> : IJob<T> where T : IData {
        public T JobData { get { return GetData(); } }
        public abstract void Run();
        public abstract T GetData();
    }
