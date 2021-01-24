    class YourClass
    {
        TimeSpan timeDiff;
    
        public void SetServerTime(DateTime serverTime)
        {
            timeDiff = DateTime.Now - serverTime;
        }
    
        public DateTime ServerTime => DateTime.Now.Add(timeDiff);
    }
