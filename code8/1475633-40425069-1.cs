    using System;
    using NUnit.Framework;
    namespace MyTests
    {
        public class MyTestClass
        {
            [TestCase(1, 1, 2, TestName = "Custom name of the first row")]
            [TestCase(1, 2, 3)]
            [TestCase(1, -1, 1)]
            public void MyTestMethod(int a1, int a2, int result)
            {
                ExecSumTest(a1, a2, result);
            }
        }
    }
