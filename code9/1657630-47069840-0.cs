    public static class ClassData
    {
        public static string GetData()
        {
            //Wish to mock TestResult method
            TestData TD = new TestData();
            string FinalResult = TestData.TestResult();
            //Some logic
            return FinalResult;
        }
        public static TestData TestData { private get; set; }
    }
    public class TestData
    {
        public string TestResult()
        {
            return string.Empty;
        }
    }
