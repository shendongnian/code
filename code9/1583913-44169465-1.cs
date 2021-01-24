    static class MyClass
    {
        private static DateTime NextEntry = DateTime.Now;
        private static ReaderWriterLockSlim timeLock = new ReaderWriterLockSlim();
    
        private static object lockObject = new object();
    
        public static bool IsDataCorrect(string testString)
        {
            try
            {
                bool tryEnterSuccess = false;
                try
                {
                    timeLock.EnterReadLock()
                    if (DateTime.Now < NextEntry) return false;
                }
                finally 
                {
                    timeLock.ExitReadLock()
                }
                Monitor.TryEnter(lockObject, ref tryEnterSuccess);
                if (!tryEnterSuccess) return false;
    
                var uri = $"https://something.com";
    
                bool htmlCheck = GetDocFromUri(uri, 2);
    
                //Fast Evaluations
                //...           
                try
                {
                    timeLock.EnterWriteLock()
                    NextEntry = DateTime.Now.AddMilliseconds(500);
                } finally {
                    timeLock.ExitWriteLock()
                }
                return htmlCheck;
            } finally {
                if (tryEnterSuccess) Monitor.Exit(lockObject);
            }
        }
    }
