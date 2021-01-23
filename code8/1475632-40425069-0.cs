    using System;
    using NUnit.Framework;
    namespace MyTests
    {
        public class MyTestClass
        {
            private static object[] myDataSource => new object[]
                {
                    new object[] { 1, 1, 2 },
                    new object[] { 1, 2, 3 },
                    new object[] { 1, -1, 1 },
                }
            [TestCaseSource(nameof(myDataSource))]
            public void MyTestMethod(int a1, int a2, int result)
            {
                ExecSumTest(a1, a2, result);
            }
        }
    }
