    class YourClass
    {
        TimeSpan timeDiff;
    
        public void SetServerTime(DateTime serverTime)
        {
            timeDiff = serverTime - DateTime.Now;
        }
    
        public DateTime ServerTime => DateTime.Now.Add(timeDiff);
    }
