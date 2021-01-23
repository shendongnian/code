    class Tests
    {
        private static readonly object testLock = new object();
        private List<Test> executedTests;
    
        public Tests()
        {
            ExecutedTests = new List<Test>();
        }
        public void AddTest(Test t)
        {
            lock(testLock)
            {
                executedTests.Add(t);
            }
        }
        public IEnumerable<Test> GetTests()
        {
            lock(testLock)
            {
                return executedTests.ToArray();
            }
        }
        [...]
    }
