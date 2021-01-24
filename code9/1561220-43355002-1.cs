    class FakeSchedule : Schedule
    {
        public bool TransactionStarted { get; set; }
        public new void BeginTransaction()
        {
            TransactionStarted = true;
        } 
    }
