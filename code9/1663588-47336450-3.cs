    class YourWebservice
    {
        static Queue<Error> _GlobalQueue = new Queue<Error>();
        static readonly object queueLock = new object();
        static Thread errorLogger;
        public void SomeWebserviceMethod()
        {
            //Some code...
            //.
            //.
            //Here we want to log an error
            EnqueueError(new Error());
        }
        private void EnqueueError(Error err )
        {
            lock(queueLock)
            {
                _GlobalQueue?.Enqueue(err);
                if ( errorLogger==null || !(errorLogger?.IsAlive ?? false) )
                {
                    errorLogger = new Thread(new ThreadStart(WriteErrors));
                    errorLogger?.Start();
                }
            }
        }
        private static Error DequeueError()
        {
            try
            {
                lock (queueLock)
                {
                    return  _GlobalQueue?.Dequeue();
                }
            }
            catch(Exception)
            {
                //if we got here it means queue is empty.
            }
            return null;
        }
        private static void WriteErrors()
        {
           Error error = DequeueError();
           while (error!=null)
           {
                //Log error here
                //...
                //..
                error = DequeueError();               
           }
        }
    }
