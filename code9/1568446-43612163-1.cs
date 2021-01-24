    public class WorkPoint<T> where T : IModel
    {
        public Func<T, T> Do { get; }
        public Func<T, T> ReadyToWork { get; }
        protected WorkPoint(Func<T, T> f, Func<T, T> r)
        {
            Do = f;
            ReadyToWork = r;
        }
    }
    // Create a simple class like this for evert worker type you need
    public class FirstWorkPoint : WorkPoint<ModelFirst>
    {
        private FirstWorkPoint() :
            base(FirstWorker.Instance().Do, FirstWorker.Instance().ReadyToWork)
        { }
        // Public method to get a new base instance
        public static WorkPoint<ModelFirst> New() => new FirstWorkPoint();
    }
