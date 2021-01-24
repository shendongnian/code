    class FakeSchedule : Schedule {
        public bool TransactionStarted { get; set; }
        // "new" method hides the base class method
        public new void BeginTransaction() {
            TransactionStarted = true;
        } 
    }
