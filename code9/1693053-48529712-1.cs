    [TestClass()]
    public class ScenarioOne : SuiteBase
    {
        [ClassInitialize]
        public static void ClassInit()
        {
            SuiteBase.ClassInit();
            //Create the data for the all test cases under one TestClass          
        }
        [TestMethod()]
        public void TestCase1()
        {
            //Blah Blah
        }
        [TestMethod()]
        public void TestCase2()
        {
            //Blah Blah
        }
        [TestMethod()]
        public void TestCase3()
        {
            //Blah Blah
        }
    }
