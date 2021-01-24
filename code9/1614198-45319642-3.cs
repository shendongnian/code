    // in the parent fixture...
    public abstract class TestCases : IEnumerable
    {
        protected abstract List<List<object>> Cases { get; }
    
        public IEnumerator GetEnumerator()
        {
            return Cases.GetEnumerator();
        }
    }
    
    // in tests
    private class TestCasesForTestFoobar : TestCases
    {
        protected override List<List<object>> Cases => /* sets of args */
    }
    
    [TestCaseSource(typeof(TestCasesForTestFoobar))]
    public void TestFoobar(List<object> args)
    {
        // implemented test
    }
