    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void TestMethod1()
        {
            var x = 2;
            var y = 1 + 1;
            Assert.AreEqual(x, y);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(true, true);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine(TestContext.TestName);
        }
    }
