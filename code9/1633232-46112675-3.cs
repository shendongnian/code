    using ConsoleWebChromiumSample;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace ChromTests
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestChromiumDemo()
            {
                ChromiumRunner runner = new ChromiumRunner();
                runner.RunChromiumDemo();
            }
        }
    }
