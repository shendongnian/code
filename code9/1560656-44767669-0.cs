    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            int a = 100;
            int b = 100;
            Assert.AreEqual(a, b);
        }
    }
