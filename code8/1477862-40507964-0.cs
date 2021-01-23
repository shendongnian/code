    [TestFixture]
    public class ImportTests
    {
        static ImportTests() 
        {
            //Step 1 
            //run your set-up routine
        }
        
        //Step 3
        [Test, TestCaseSource(nameof(ImportTests.TestCases))]
        public bool PropertyTest(string s) => string.IsNullOrEmpty(s);
    
        //Step 2
        public static IEnumerable TestCases => new[] {new TestCaseData("").Returns(true)};
    }
