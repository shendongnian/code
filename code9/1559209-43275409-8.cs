    // Change this class to contain whatever data you need
    public class MyEventArgs 
    {
        public string Data { get; set; }
    }
    public class Worker
    {
        public event EventHandler<MyEventArgs> WorkComplete = delegate { };
        private readonly object _locker = new object();
        public void Start()
        {
            new Thread(DoWork).Start();
        }
        void DoWork()
        {
            // add a 'lock' here if this shouldn't be run in parallel 
            Thread.Sleep(5000); // ... massive computation
            WorkComplete(this, null); // pass the result of computations with MyEventArgs
        }
    }
    class MyClass
    {
        private readonly Worker _worker = new Worker();
        public MyClass()
        {
            _worker.WorkComplete += OnWorkComplete;
        }
        private void OnWorkComplete(object sender, MyEventArgs eventArgs)
        {
            // Do something with result here
        }
        private void Update()
        {
            _worker.Start();
        }
    }
