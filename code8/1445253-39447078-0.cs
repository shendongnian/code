    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.TestCase", "http://tfsurl:8080/tfs/DefaultCollection;teamprojectname", "TestCaseID", DataAccessMethod.Sequential), TestMethod]
            public void Test1()
    {
        string expected = "t1";
        string actual = TestContext.DataRow["actual"].ToString();
        Assert.AreEqual(expected, actual);
    }
            public TestContext TestContext
            {
                get { return testContextInstance; }
                set { testContextInstance = value; }
            }
            private TestContext testContextInstance;
        }
    }
