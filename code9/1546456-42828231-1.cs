    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace UnitTestProject1
    {
        public class SkipInitializeAttribute : Attribute
        {
        }
        [TestClass]
        public class UnitTest1
        {
            public TestContext TestContext { get; set; }
            private bool IsInitializationDone { get; set; }
            [TestInitialize]
            public void Initialize()
            {
                bool skipInitialize = GetType().GetMethod(TestContext.TestName).GetCustomAttributes<SkipInitializeAttribute>().Any();
                if (!skipInitialize)
                {
                    // Initialization code here
                    IsInitializationDone = true;
                }
            }
            [TestMethod]
            public void TestMethod1()
            {
                Assert.IsTrue(IsInitializationDone);
            }
            [TestMethod]
            [SkipInitialize]
            public void TestMethod2()
            {
                Assert.IsFalse(IsInitializationDone);
            }
            [TestMethod]
            public void TestMethod3()
            {
                Assert.IsTrue(IsInitializationDone);
            }
        }
    }
