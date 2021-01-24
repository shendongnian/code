    // in the parent fixture...
    public abstract class TestCases : IEnumerable
    {
        protected abstract List<object> Arguments;
    
        public IEnumerator GetEnumerator()
        {
            return Arguments.GetEnumerator();
        }
    }
    
    // in tests
    private class TestCasesForTestFoobar : TestCases
    {
        protected override List<object> Arguments => /* args */
    }
    
    [TestCaseSource(typeof(TestCasesForTestFoobar))]
    public void TestFoobar(List<object> args)
    {
        // implemented test
    }
