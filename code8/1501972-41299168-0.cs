    public class APIClass
    {
        private const string MutexName = "FAA9569-7DFE-4D6D-874D-19123FB16CBC-8739827-[SystemSpecicString]";
        private Mutex _globalMutex;
        private bool _owned = false;
        object baton = new object();
        static int count = 0;
        public void SynchronizeMe()
        {
            _globalMutex = new Mutex(true, MutexName, out _owned);
            while(true)
            {
                while (!_owned)
                {
                    // did not get the mutex, wait for it.
                    _owned = _globalMutex.WaitOne(timeToWait);
                }
                int temp = count;
                Thread.Sleep(5000);
                count = temp + 1;
                Console.WriteLine("Thread Id " + Thread.CurrentThread.ManagedThreadId + " Name:" + Thread.CurrentThread.Name + " incremented count to " + count);
                Thread.Sleep(1000);
            }
        }
    }
