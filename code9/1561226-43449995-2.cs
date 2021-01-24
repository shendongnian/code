        [TestMethod]
        public void BeginTransaction_WhenCalled_SetsTransactionStartedToTrue()
        {
            Schedule schedule = new FakeSchedule();
            var connection = new SqlConnection();
            schedule.Testable(schedule.BeginTransaction);
            Assert.IsTrue(((FakeSchedule)schedule).TransactionStarted); 
        }
