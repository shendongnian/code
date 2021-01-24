    using NUnit.Framework;
    using System;
    namespace UnitTestProject1
    {
        public class Tests
        {
            [SetUp]
            public void SetUpFunc()
            {
                var asd = TestContext.CurrentContext.Test.Name;
                Console.WriteLine($"Setup: {asd}");
            }
            [Test(Description = "testingSetup")]
            public void TestName123()
            {
                var asd = TestContext.CurrentContext.Test.Name;
                Console.WriteLine($"Test: {asd}");
                Assert.IsTrue(false);
            }
        }
    }
