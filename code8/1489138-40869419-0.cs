    public abstract class Worker
    {
        public bool DoingWork { get; set; }
        private event Action WorkCompleted; 
        public void DoWork()
        {
            DoingWork = true;
            DoWorkImplementation();
            DoingWork = false;
            WorkCompleted?.Invoke();
        }
        protected abstract void DoWorkImplementation();
    }
    public class MyWorker : Worker
    {
        protected override void DoWorkImplementation()
        {
            Console.WriteLine("Hello World!");
        }
    }
