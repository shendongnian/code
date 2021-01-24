    public class Worker
    {
        private bool working = false;
        private bool stop = false;
        
        public void Start()
        {
            if (!working)
            {
                new Thread(Work).Start();
                working = true;
            }
        }
        
        public void Work()
        {
            while (!stop)
            {
                // TODO: actual work without volatile operations
            }
        }
        
        public void Stop()
        {
            stop = true;
        }
    }
