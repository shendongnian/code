    [TestFixture]
    public class UnitTest
    {
        private readonly ILog logger = LogManager.GetLogger("your_logger");
        [Test]
        public void Demo()
        {
            Assert.AreEqual(2, 3, "wrong");
        }
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
                logger.Error(TestContext.CurrentContext.Result.Message);
        }
    }
