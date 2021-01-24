    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SomeClass test = new Test();
            // Insert whatever value you expect here
            Assert.AreEqual(10, test.MethodYouWantToTest());
        }
    }
