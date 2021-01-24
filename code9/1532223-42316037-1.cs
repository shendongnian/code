    public interface ISomeInterface
    {
        void MyCallBackMethod();
    }
    public class MyClass : ISomeInterface
    {
        private int Data { get; set; }
        public void MyCallBackMethod()
        {
            Dictionary<int, int> myDict = new Dictionary<int, int>();
            myDict.Add(1, 1);
            // access this.Data - this is the part that would
            // make problems in case of multithreaded access
        }
    }
    public class ThreadSafe : ISomeInterface
    {
        private ISomeInterface Contained { get; }
        private object SyncRoot { get; } = new object();
        public ThreadSafe(ISomeInterface contained)
        {
            this.Contained = contained;
        }
        public void MyCallBackMethod()
        {
            lock (this.SyncRoot)
            {
                this.Contained.MyCallBackMethod();
            }
        }
    }
