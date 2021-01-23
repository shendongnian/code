    using ConsoleApplication6;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Reflection;
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestInitialize]
            public void Init()
            {
               AppDomain currentDomain = AppDomain.CurrentDomain;
               currentDomain.AssemblyResolve += MyResolveEventHandler;
            }
            [TestMethod]
            public void TestMethod1() { Assert.AreEqual(new MyClass().DoSomething(), 1); }
            [TestMethod]
            public void TestMethod2() { Assert.AreEqual(new MyClass().DoSomething(), 1); }
            private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
            {
                return Assembly.LoadFile(@"C:\MyPath\MyAssembly.dll");
            }
        }
    }
